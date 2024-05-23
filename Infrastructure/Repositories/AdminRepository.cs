using System.Security.Cryptography;
using System.Text;
using Application;
using Domain;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Infrastructure;

public class AdminRepository(ApplicationDbContext applicationDbContext, IJWTService jWTService): IAdminRepository
{
    private readonly ApplicationDbContext _context = applicationDbContext;
    private readonly IJWTService _jwtService = jWTService; 
    public async Task<ApiResponse<LoginResponse>> Login(LoginRequest request)
    {
        var target = await _context.Admins.Where(x => x.Email == request.Email).FirstOrDefaultAsync();
        bool isTargetNull = target is null;
        if (isTargetNull) 
            return ApiResponse<LoginResponse>.NotFound();
        bool isValid = ValidateUser(target.Password, target.Salt, request.Password);
        string token = _jwtService.GenerateJwtToken(request.Password, request.Email, target.UserRoleId, target.FullName);
        return ApiResponse<LoginResponse>.Success(new LoginResponse{ Token = token});
    }
    public bool ValidateUser(byte[] hashedPassword, byte[] Salt, string Password) 
    {
        byte[] hashed = SHA256.HashData(Encoding.UTF8.GetBytes(Password));
        HMACSHA256 hMACSHA256 = new HMACSHA256(Salt);
        byte[] result = hMACSHA256.ComputeHash(hashed);
        bool isValid = hashedPassword.SequenceEqual(result);
        return isValid; 
    }   
    public async Task<ApiResponse<CreateAdminResponse>> Register(CreateAdminRequest request)
    {
        byte[] Salt = SHA256.HashData(Encoding.UTF8.GetBytes(Guid.NewGuid().ToString()));
        HMACSHA256 hMACSHA256 = new(Salt);
        byte[] HashedPassword = hMACSHA256.ComputeHash(SHA256.HashData(Encoding.UTF8.GetBytes(request.Password)));
        Admin admin = new() {FullName = request.FullName, Email = request.Email, Salt = Salt, Password = HashedPassword};
        await _context.Admins.AddAsync(admin);
        return ApiResponse<CreateAdminResponse>.Success(new CreateAdminResponse{});
    }
}

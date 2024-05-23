using System.Security.Cryptography;
using System.Text;
using Application;
using Domain;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Infrastructure;

public class UserRepository(ApplicationDbContext applicationDbContext, IJWTService jWTService) : IUserRepository
{
    private readonly ApplicationDbContext _context = applicationDbContext; 
    private readonly IJWTService JWTService = jWTService;
    public async Task<ApiResponse<CreateUserResponse>> Create(CreateUserRequest request)
    {   
        string guid = Guid.NewGuid().ToString();    
        byte[] salt = SHA256.HashData(Encoding.UTF8.GetBytes(guid));
        HMACSHA256 hMACSHA256= new(salt);
        byte[] hashed = hMACSHA256.ComputeHash(Encoding.UTF8.GetBytes(request.Password));
        await _context.Users.AddAsync(new User {UserName = request.UserName,  Email = request.Email, Salt = salt, Password = hashed});
        return ApiResponse<CreateUserResponse>.Success(new CreateUserResponse{});
    }

    public async Task<ApiResponse<GetUserResponse>> GetUser(GetUserRequest request)
    {
        bool IsUserIdNull = request.Id is null;
        var target = await _context.Users.Where(x => IsUserIdNull ||  x.Id == request.Id).Select(x => new GetUserDto {UserName = x.UserName, Email = x.Email}).ToListAsync();
        return ApiResponse<GetUserResponse>.Success(new GetUserResponse{Users = target});
    }

    public async Task<ApiResponse<LoginResponse>> Login(LoginRequest request)
    {
        var Target = await _context.Users.Where(u => u.Email == request.Email).FirstOrDefaultAsync();
        bool isValid = ValidateUser(Target, request.Password, request.Email);
        if (!isValid) {
            return null;
        }
        string Token = JWTService.GenerateJwtToken(request.Password, Target.Email, Target.UserRoleId, Target.UserName);
        return ApiResponse<LoginResponse>.Success(new LoginResponse{Token = Token});
    }
    public bool ValidateUser(User user, string Password, string Email) {
       HMACSHA256 hMACSHA256 = new (user.Salt);
       return user.Password.SequenceEqual(hMACSHA256.ComputeHash(Encoding.UTF8.GetBytes(Password)));
    }
}

using System.Security.Cryptography;
using System.Text;
using Application;
using Domain;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Infrastructure;

public class CourierRepository(ApplicationDbContext applicationDbContext, IJWTService jWTService) : ICourierRepository
{
    private readonly ApplicationDbContext _context = applicationDbContext;
    private readonly IJWTService _jwtService = jWTService;  
    public async Task<ApiResponse<LoginResponse>> Login(LoginRequest request)
    {
      var target = await _context.Couriers.Where(x => x.Email == request.Email).FirstOrDefaultAsync();
      bool isNotExist = target is null; 
      if (isNotExist) 
         return ApiResponse<LoginResponse>.NotFound();
      bool isValid = ValidateUser(target, request.Password);
      if (!isValid) 
         return ApiResponse<LoginResponse>.Error();
      string Token = _jwtService.GenerateJwtToken(request.Password, request.Email, target.UserRoleId, target.FullName);
      return ApiResponse<LoginResponse>.Success(new LoginResponse{Token = Token});
    }
    public bool ValidateUser(Courier courier,string password) 
    {
      HMACSHA256 hMACSHA256 = new (courier.Salt);
      byte[] hashed = hMACSHA256.ComputeHash(SHA256.HashData(Encoding.UTF8.GetBytes(password)));
      return courier.Password.SequenceEqual(hashed);
    }
    public async Task<ApiResponse<CreateCourierResponse>> Create(CreateCourierRequest request)
    {
      byte[] Salt =  SHA256.HashData(Encoding.UTF8.GetBytes(Guid.NewGuid().ToString()));
      HMACSHA256 hMACSHA256 = new (Salt);
      byte[] HashedPassword =  hMACSHA256.ComputeHash(SHA256.HashData(Encoding.UTF8.GetBytes(request.Password)));
      await _context.Couriers.AddAsync(new Courier {AdminId = request.AdminId, FullName = request.FullName, Email = request.Email, UserRoleId = (int)Roles.Courier , Salt = Salt, Password = HashedPassword});
      return ApiResponse<CreateCourierResponse>.Success(new CreateCourierResponse{});
    }
    public async Task<ApiResponse<GetCourierResponse>> Get(GetCourierRequest request)
    {
        var Couriers = await _context.Couriers.Where(c => c.AdminId == request.AdminId).Select(x => new GetCourierDto {Adminid = x.AdminId, CourierName = x.FullName, StatusId = (int)x.UserRoleId}).ToListAsync();
        return ApiResponse<GetCourierResponse>.Success(new GetCourierResponse {Couriers = Couriers});
    }
}

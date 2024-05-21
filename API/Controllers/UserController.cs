using Domain;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API;

[ApiController]
[Route("users")]
public class UserController(IUserService userService)
{
    public IUserService UserService { get; set; } = userService;

    [HttpPost]
    [Route("register")]
    public async Task<ApiResponse<CreateUserResponse>> Create([FromForm] CreateUserRequest request) {
        var result = await UserService.CreateUser(request);
        return ApiResponse<CreateUserResponse>.Success(result);
    }
    [Route("login")]
    [HttpPost]
    public async Task<ApiResponse<LoginResponse>> Login([FromForm] LoginRequest request) {
        var result = await UserService.Login(request);
        return ApiResponse<LoginResponse>.Success(result);
    }
    [HttpGet]
    public async Task<ApiResponse<GetOrderResponse>> Get([FromQuery] GetOrderRequest request) {
        var result = await UserService.GetOrder(request);
        return ApiResponse<GetOrderResponse>.Success(result);
    }
}

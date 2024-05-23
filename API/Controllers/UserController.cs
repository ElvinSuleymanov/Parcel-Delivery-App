using Application;
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
        return result;
    }
    [HttpPost]
    [Route("login")]
    public async Task<ApiResponse<LoginResponse>> Login([FromForm] LoginRequest request) {
        var result = await UserService.Login(request);
        return result;
    }
    [HttpGet]
    public async Task<ApiResponse<GetUserResponse>> GetUser([FromQuery] GetUserRequest request) {
        var result = await UserService.GetUser(request);
        return result;
    }
}

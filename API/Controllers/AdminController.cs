using Application;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API;

[Route("/admin")]
[ApiController]
public class AdminController(IAdminService _adminService)
{
    private readonly IAdminService _adminService = _adminService;
    [Route("login")]
    [HttpPost]
    public async Task<ApiResponse<LoginResponse>> Login([FromForm] LoginRequest loginRequest)   {
        var result = await _adminService.Login(loginRequest);
        return result;
    }
    [Route("register")]
    [HttpPost]
    public async Task<ApiResponse<CreateAdminResponse>> Register([FromForm] CreateAdminRequest createAdminRequest) {
        var result = await _adminService.Register(createAdminRequest);
        return result;
    }
}

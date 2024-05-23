using Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API;

[Route("/courier")]
[ApiController]
public class CourierController(ICourierService courierService)
{
    private readonly ICourierService _courierService = courierService;
    [Authorize(Roles = "30")]
    [HttpPost]
    [Route("register")]
    public async Task<ApiResponse<CreateCourierResponse>> Create([FromForm] CreateCourierRequest request)  {
        var result = await _courierService.Create(request);
        return result;
    }
    [HttpPost]
    [Route("login")]
    public async Task<ApiResponse<LoginResponse>> Login([FromForm] LoginRequest request)  {
        var result = await _courierService.Login(request);
        return result;
    }
    [HttpGet]
    public async Task<ApiResponse<GetCourierResponse>> Get([FromQuery] GetCourierRequest  request)  {
        var result = await _courierService.Get(request);
        return result;
    }
}

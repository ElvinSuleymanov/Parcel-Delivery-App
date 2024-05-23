using Application;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API;

[ApiController]
[Route("/order")]
public class OrderController(IOrderService orderService)
{
    private readonly IOrderService _orderService = orderService;

    [HttpGet]
    public async Task<ApiResponse<GetOrderResponse>> GetOrder([FromQuery] GetOrderRequest request ) {
        var result = await _orderService.Get(request);
        return result;
    }
    [Authorize(Roles = "30, 20")]
    [HttpPut]
    public async Task<ApiResponse<UpdateOrderResponse>> Update([FromForm] UpdateOrderRequest request ) {
        var result = await _orderService.Update(request);
        return result;
    }
    [HttpPost]
    [Authorize(Roles = "10")]
    public async Task<ApiResponse<CreateOrderResponse>> Create([FromForm] CreateOrderRequest request ) {
        var result = await _orderService.Create(request);
        return result;
    }
    [HttpDelete]
     public async Task<ApiResponse<DeleteOrderResponse>> Delete([FromQuery] DeleteOrderRequest request ) {
        var result = await _orderService.Delete(request);
        return result;
    }
}

using Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API;

[ApiController]
[Route("/product")]
[Authorize(Roles = "30")]
public class ProductController(IProductService service)
{
    public IProductService ProductService = service;
    [HttpPost]
    public async Task<ApiResponse<CreateProductResponse>> Create([FromForm] CreateProductRequest request) {
        var result = await ProductService.CreateProduct(request);
        return result;  
    }
    [HttpGet]
    public async Task<ApiResponse<GetProductResponse>> Get([FromQuery] GetProductRequest request) {
        var result = await ProductService.GetProduct(request);
        return result;  
    }
}

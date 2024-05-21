using Domain;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API;

[ApiController]
[Route("/product")]
public class ProductController(IProductService service)
{
    public IProductService ProductService = service;

    [HttpPost]
    public async Task<ApiResponse<CreateProductResponse>> Create([FromForm] CreateProductRequest request) {
        var result = await ProductService.CreateProduct(request);
        return ApiResponse<CreateProductResponse>.Success(result);  
    }
     [HttpGet]
    public async Task<ApiResponse<GetProductResponse>> Get([FromQuery] GetProductRequest request) {
        var result = await ProductService.GetProduct(request);
        return ApiResponse<GetProductResponse>.Success(result);  
    }
}

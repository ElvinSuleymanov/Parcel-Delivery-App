using Application;
using Domain;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Infrastructure;

public class ProductRepository(ApplicationDbContext context) : IProductRepository
{
    private readonly ApplicationDbContext _context = context;
    public async Task<ApiResponse<CreateProductResponse>> Create(CreateProductRequest request)
    {
      await _context.Products.AddAsync(new Product{ ProductName = request.Name});
      return ApiResponse<CreateProductResponse>.Success(new CreateProductResponse{});
    }
    public async Task<ApiResponse<GetProductResponse>> Get(GetProductRequest request)
    {
        var target = await _context.Products.Where(p => request.Id == null || p.Id == request.Id).Select(x => new GetProductDto {Id = x.Id, ProductName = x.ProductName}).ToListAsync(); 
        return  ApiResponse<GetProductResponse>.Success(new GetProductResponse{Products = target});
    }
}

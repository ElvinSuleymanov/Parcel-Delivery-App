using Models;

namespace Application;

public interface IProductRepository
{
    public Task<ApiResponse<CreateProductResponse>> Create(CreateProductRequest request);
    public Task<ApiResponse<GetProductResponse>> Get(GetProductRequest request);
}
using Models;

namespace Application;

public interface IProductService
{
    public Task<ApiResponse<CreateProductResponse>> CreateProduct(CreateProductRequest request);
    public Task<ApiResponse<GetProductResponse>> GetProduct(GetProductRequest request);
}

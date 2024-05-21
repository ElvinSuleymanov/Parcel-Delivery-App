using Models;

namespace Domain;

public interface IProductService
{
    public Task<CreateProductResponse> CreateProduct(CreateProductRequest request);
    public Task<GetProductResponse> GetProduct(GetProductRequest request);
}

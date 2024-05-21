using Models;

namespace Domain;

public interface IProductRepository
{
    public Task<CreateProductResponse> Create(CreateProductRequest request);
    public Task<GetProductResponse> Get(GetProductRequest request);
}
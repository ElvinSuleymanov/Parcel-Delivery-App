using Domain;
using Models;

namespace Infrastructure;

public class ProductService(IUnitOfWork uow) : IProductService
{
    public IUnitOfWork UnitOfWork = uow;
    public async Task<CreateProductResponse> CreateProduct(CreateProductRequest request)
    {
       var result = await UnitOfWork.Products.Create(request);
       await UnitOfWork.SaveChangesAsync();
       return result;
    }

    public async Task<GetProductResponse> GetProduct(GetProductRequest request)
    {
       var result = await UnitOfWork.Products.Get(request);
       return result;
    }
}

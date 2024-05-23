using Application;
using Models;

namespace Infrastructure;

public class ProductService(IUnitOfWork uow, IProductRepository productRepository) : IProductService
{
    public IUnitOfWork UnitOfWork = uow;
    private readonly IProductRepository ProductRepository = productRepository;
    public async Task<ApiResponse<CreateProductResponse>> CreateProduct(CreateProductRequest request)
    {
       var result = await ProductRepository.Create(request);
       await UnitOfWork.SaveChangesAsync();
       return result;
    }

    public async Task<ApiResponse<GetProductResponse>> GetProduct(GetProductRequest request)
    {
       var result = await ProductRepository.Get(request);
       return result;
    }
}

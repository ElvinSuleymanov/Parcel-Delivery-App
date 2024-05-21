using Domain;
using Models;

namespace Infrastructure;

public class AdminService(IUnitOfWork uow) : IAdminService
{
    public IUnitOfWork UnitOfWork { get; set; } = uow;

    public Task<CreateOrderResponse> Assign(CreateOrderRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<GetOrderResponse> GetOrder(GetOrderRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<UpdateOrderResponse> UpdateOrder(UpdateOrderRequest request)
    {
        throw new NotImplementedException();
    }
}

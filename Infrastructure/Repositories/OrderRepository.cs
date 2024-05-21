using Domain;
using Models;

namespace Infrastructure;

public class OrderRepository : IOrderRepository
{
    public Task<CreateOrderResponse> Create(CreateOrderRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<DeleteOrderResponse> Delete(DeleteOrderRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<GetOrderResponse> Get(GetOrderRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<UpdateOrderResponse> Update(UpdateOrderRequest request)
    {
        throw new NotImplementedException();
    }
}

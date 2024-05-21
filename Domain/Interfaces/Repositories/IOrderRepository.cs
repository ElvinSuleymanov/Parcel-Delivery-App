using Models;

namespace Domain;

public interface IOrderRepository
{
    public Task<CreateOrderResponse> Create(CreateOrderRequest request);
    public Task<UpdateOrderResponse> Update(UpdateOrderRequest request);
    public Task<DeleteOrderResponse> Delete(DeleteOrderRequest request);
    public Task<GetOrderResponse> Get(GetOrderRequest request);    
}

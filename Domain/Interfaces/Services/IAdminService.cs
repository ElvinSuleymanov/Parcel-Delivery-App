using Models;

namespace Domain;

public interface IAdminService
{
    public Task<UpdateOrderResponse> UpdateOrder(UpdateOrderRequest request);
    public Task<GetOrderResponse> GetOrder(GetOrderRequest request);
    public Task<CreateOrderResponse> Assign(CreateOrderRequest request);
}

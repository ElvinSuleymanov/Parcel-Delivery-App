using Models;

namespace Application;

public interface IOrderService
{
    public Task<ApiResponse<GetOrderResponse>> Get(GetOrderRequest request);
    public Task<ApiResponse<UpdateOrderResponse>> Update(UpdateOrderRequest request);
    public Task<ApiResponse<CreateOrderResponse>> Create(CreateOrderRequest request);
    public Task<ApiResponse<DeleteOrderResponse>> Delete(DeleteOrderRequest request);
}

using Application;
using Domain;
using Models;


namespace Infrastructure;

public class OrderService(IOrderRepository orderRepository, IUnitOfWork uow) : IOrderService
{
    private readonly IOrderRepository _orderRepository = orderRepository;
    private readonly IUnitOfWork _unitOfWork = uow;
    public async Task<ApiResponse<CreateOrderResponse>> Create(CreateOrderRequest request)
    {
        var result = await _orderRepository.Create(request);
        await _unitOfWork.SaveChangesAsync();
        return result;
    }
    public async Task<ApiResponse<DeleteOrderResponse>> Delete(DeleteOrderRequest request)
    {
        var result = await _orderRepository.Delete(request);
        return result;
    }
    public async Task<ApiResponse<GetOrderResponse>> Get(GetOrderRequest request)
    {
        var result = await _orderRepository.Get(request);
        return result;
    }
    public async Task<ApiResponse<UpdateOrderResponse>> Update(UpdateOrderRequest request)
    {
       var result = await _orderRepository.Update(request);
       await _unitOfWork.SaveChangesAsync();
       return result;
    }
}

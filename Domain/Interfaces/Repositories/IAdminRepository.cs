
using Models;

namespace Domain;

public interface IAdminRepository
{
    public Task<UpdateOrderResponse> ChangeParcelStatus(UpdateOrderRequest request);
    public Task<GetOrderResponse> GetParcel(GetOrderRequest request);
    public Task<CreateCourierResponse> CreateCourier(CreateCourierRequest request);
    public Task<LoginResponse> Login(LoginRequest request);
    public Task<CreateAdminResponse> Register(CreateAdminRequest request);
    public Task GetCourier();
}

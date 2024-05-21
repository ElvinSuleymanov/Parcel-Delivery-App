using Models;

namespace Domain;

public interface ICourierRepository
{
    public Task<LoginResponse> Login(LoginRequest request);
    public Task<GetOrderResponse> GetParcel(GetOrderRequest request);
}

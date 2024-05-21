using Domain;
using Models;

namespace Infrastructure;

public class CourierRepository : ICourierRepository
{
    public Task<GetOrderResponse> GetParcel(GetOrderRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<LoginResponse> Login(LoginRequest request)
    {
        throw new NotImplementedException();
    }
}

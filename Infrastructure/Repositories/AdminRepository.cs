using Domain;
using Models;

namespace Infrastructure;

public class AdminRepository : IAdminRepository
{
    public Task<UpdateOrderResponse> ChangeParcelStatus(UpdateOrderRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<CreateCourierResponse> CreateCourier(CreateCourierRequest request)
    {
        throw new NotImplementedException();
    }

    public Task GetCourier()
    {
        throw new NotImplementedException();
    }

    public Task<GetOrderResponse> GetParcel(GetOrderRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<LoginResponse> Login(LoginRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<CreateAdminResponse> Register(CreateAdminRequest request)
    {
        throw new NotImplementedException();
    }
}

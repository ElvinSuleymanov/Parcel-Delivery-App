using Domain;
using Models;

namespace Infrastructure;

public class UserService(IUnitOfWork uow) : IUserService
{
    public IUnitOfWork UnitOfWork = uow;

    public async Task<CreateOrderResponse> CreateOrder(CreateOrderRequest request)
    {
       var result = await UnitOfWork.Orders.Create(request);
       await UnitOfWork.SaveChangesAsync();
       return result;
    }

    public async Task<CreateUserResponse> CreateUser(CreateUserRequest request)
    {
       var result = await UnitOfWork.Users.Create(request);
       await UnitOfWork.SaveChangesAsync();
       return result;
    }

    public async Task<GetOrderResponse> GetOrder(GetOrderRequest request)
    {
        var result = await UnitOfWork.Orders.Get(request);
        return result;
    }

    public async Task<LoginResponse> Login(LoginRequest request)
    {
       var result = await UnitOfWork.Users.Login(request);
       return result;
    }
}

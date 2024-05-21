using Models;

namespace Domain;

public interface IUserService
{
    public Task<CreateUserResponse> CreateUser(CreateUserRequest request);
    public Task<LoginResponse> Login(LoginRequest request);
    public Task<GetOrderResponse> GetOrder(GetOrderRequest request);
    public Task<CreateOrderResponse> CreateOrder(CreateOrderRequest request);
}

using Domain;
using Models;

namespace Infrastructure;

public class UserRepository : IUserRepository
{
    public Task<CreateUserResponse> Create(CreateUserRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<LoginResponse> Login(LoginRequest request)
    {
        throw new NotImplementedException();
    }
}

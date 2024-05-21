using Models;

namespace Domain;

public interface IUserRepository
{
    public Task<CreateUserResponse> Create(CreateUserRequest request);
    public Task<LoginResponse> Login(LoginRequest request);

}

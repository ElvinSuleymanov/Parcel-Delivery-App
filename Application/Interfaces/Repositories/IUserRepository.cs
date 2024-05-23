using Models;

namespace Application;

public interface IUserRepository
{
    public Task<ApiResponse<CreateUserResponse>> Create(CreateUserRequest request);
    public Task<ApiResponse<LoginResponse>> Login(LoginRequest request);
    public Task<ApiResponse<GetUserResponse>> GetUser(GetUserRequest request);
}

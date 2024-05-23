using Models;

namespace Application;

public interface IUserService
{
    public Task<ApiResponse<CreateUserResponse>> CreateUser(CreateUserRequest request);
    public Task<ApiResponse<LoginResponse>> Login(LoginRequest request);
    public Task<ApiResponse<GetUserResponse>> GetUser(GetUserRequest request);
}

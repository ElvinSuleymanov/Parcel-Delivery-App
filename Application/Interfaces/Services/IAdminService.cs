using Models;

namespace Application;

public interface IAdminService
{
    public Task<ApiResponse<LoginResponse>> Login(LoginRequest request);
    public Task<ApiResponse<CreateAdminResponse>> Register(CreateAdminRequest request);
}

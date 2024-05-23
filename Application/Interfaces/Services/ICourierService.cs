using Models;

namespace Application;

public interface ICourierService
{
    public Task<ApiResponse<CreateCourierResponse>> Create(CreateCourierRequest request);
    public Task<ApiResponse<LoginResponse>> Login(LoginRequest request);
    public Task<ApiResponse<GetCourierResponse>> Get(GetCourierRequest request);
}

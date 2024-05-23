using Domain;
using Models;

namespace Application;

public interface ICourierRepository
{
    public Task<ApiResponse<LoginResponse>> Login(LoginRequest request);
    public Task<ApiResponse<GetCourierResponse>> Get(GetCourierRequest request);
    public Task<ApiResponse<CreateCourierResponse>> Create(CreateCourierRequest request);
    public bool ValidateUser (Courier courier,string password);
}

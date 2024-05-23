using Models;

namespace Application;

public interface IAdminRepository
{
    public Task<ApiResponse<LoginResponse>> Login(LoginRequest request);
    public Task<ApiResponse<CreateAdminResponse>> Register(CreateAdminRequest request);
    public bool ValidateUser(byte[] hashedPassword, byte[] Salt, string Password);
}

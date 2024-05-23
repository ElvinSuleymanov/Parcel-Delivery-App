using Application;
using Models;

namespace Infrastructure;

public class AdminService(IUnitOfWork uow, IAdminRepository adminRepository) : IAdminService
{
    public IUnitOfWork UnitOfWork { get; set; } = uow;
    private readonly IAdminRepository _adminRepository = adminRepository;
    public async Task<ApiResponse<LoginResponse>> Login(LoginRequest request)
    {
      var result = await _adminRepository.Login(request);
      return result;
    }
    public async Task<ApiResponse<CreateAdminResponse>> Register(CreateAdminRequest request)
    {
       var result = await _adminRepository.Register(request);
       await uow.SaveChangesAsync();
       return result;
    }
}

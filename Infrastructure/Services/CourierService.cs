using Application;
using Models;

namespace Infrastructure;

public class CourierService(ICourierRepository courierRepository, IUnitOfWork uow) : ICourierService
{
    private readonly ICourierRepository _courierRepository = courierRepository;
    private readonly IUnitOfWork _unitOfWork = uow;
    public async Task<ApiResponse<CreateCourierResponse>> Create(CreateCourierRequest request)
    {
       var result = await _courierRepository.Create(request);
       await _unitOfWork.SaveChangesAsync();
       return result;
    }

    public async Task<ApiResponse<GetCourierResponse>> Get(GetCourierRequest request)
    {
        var result = await _courierRepository.Get(request);
        return result;
    }

    public async Task<ApiResponse<LoginResponse>> Login(LoginRequest request)
    {
       var result = await _courierRepository.Login(request);
       return result;
    }
}

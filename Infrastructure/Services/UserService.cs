using Application;
using Domain;
using Models;

namespace Infrastructure;

public class UserService(IUserRepository userRepository, IUnitOfWork uow) : IUserService
{
   private readonly IUserRepository _userRepository = userRepository;
   public IUnitOfWork UnitOfWork = uow;
    public async Task<ApiResponse<CreateUserResponse>> CreateUser(CreateUserRequest request)
    {
      var result =   await _userRepository.Create(request);
       await UnitOfWork.SaveChangesAsync();
       return result;
    }
    public async Task<ApiResponse<GetUserResponse>> GetUser(GetUserRequest request)
    {
        var result = await _userRepository.GetUser(request);
        return result;
    }

    public async Task<ApiResponse<LoginResponse>> Login(LoginRequest request)
    {
       var result = await _userRepository.Login(request);
       return result;
    }
}

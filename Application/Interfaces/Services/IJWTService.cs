namespace Application;

public interface IJWTService
{
    public string GenerateJwtToken(string Password,string Email, int RoleId, string UserName);
    public Task<bool> ValidateJwtToken(string Token);
}

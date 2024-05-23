using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application;
using Domain;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure;

public class JWTService : IJWTService
{
    public string GenerateJwtToken(string Password,string Email, int RoleId, string UserName)
    {
        SecurityTokenDescriptor descriptor = new ();
        JwtSecurityTokenHandler handler = new ();
        ClaimsIdentity identity = new ();
        identity.AddClaim(new Claim("Role", RoleId.ToString()));
        identity.AddClaim(new Claim("Email", Email));
        identity.AddClaim(new Claim("UserName", UserName));
        identity.AddClaim(new Claim(ClaimTypes.Role, RoleId.ToString()));
        descriptor.Issuer = "Elvin";
        descriptor.Audience = "ParcelApp";
        descriptor.Expires = DateTime.Now.AddDays(1);
        descriptor.Subject = identity;
        descriptor.SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes("dagQoR0Rn5B1iV2qtjwLWDt9TFWPCLuGY7uNq+rTbPlGThjxVocWJ/sWaPWAYG0p")), SecurityAlgorithms.HmacSha256Signature);
        var token = handler.CreateToken(descriptor);
        string result = handler.WriteToken(token);
        return result;   
    }
    public async Task<bool> ValidateJwtToken(string Token) {
        JwtSecurityTokenHandler handler = new ();
        TokenValidationParameters parameters = new TokenValidationParameters();
        parameters.ValidateIssuer = true;
        parameters.ValidateAudience = true;
        parameters.ValidateLifetime = true;
        parameters.ValidateIssuerSigningKey = true;
        var result = await handler.ValidateTokenAsync(Token, parameters);
        return result.IsValid;
    }
}

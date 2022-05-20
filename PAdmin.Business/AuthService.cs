using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PAdmin.Core.Business;
using PAdmin.Core.DbRepository;
using PAdmin.Entity;

namespace PAdmin.Business;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;

    public AuthService(IPasswordHashService passwordHash, IUserRepository userRepository, IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<string> Login(User user)
    {

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("JWT:secret"));
        var expirationHours = int.Parse(_configuration.GetValue<string>("JWT:expiration_hour"));

        var tokenDescription = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, user.Roles)
            }),
            Expires = DateTime.UtcNow.AddHours(expirationHours),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
        };

        var token = tokenHandler.CreateToken(tokenDescription);
        return tokenHandler.WriteToken(token);
    }

    public Task<bool> Refresh(string username)
    {
        throw new NotImplementedException();
    }
}
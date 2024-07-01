using System.IdentityModel.Tokens.Jwt;
using WebAPIBatch20.Entities;

namespace WebAPIBatch20.Services.Interfaces
{
    public interface IAuthService
    {
        string GenerateToken(User user);
    }
}

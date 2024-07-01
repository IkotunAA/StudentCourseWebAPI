using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPIBatch20.Entities;
using WebAPIBatch20.Services.Interfaces;
using WebAPIBatch20.Settings;

namespace WebAPIBatch20.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly JWT _jwt;

        public AuthService(IOptions<JWT> jwt)
        {
            _jwt = jwt.Value;
        }
        public string GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, $"{user.LastName} {user.FirstName}"),
                new Claim("uid", user.LastName)
            };

            foreach (var role in user.UserRoles)
            {
                claims.Add(new Claim("roles", role.Role.Name));
            }

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
                signingCredentials: signingCredentials);
            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
    }
}

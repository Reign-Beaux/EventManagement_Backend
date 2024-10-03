using Application.Contracts.Services;
using Application.Enums;
using Application.Models.Settings;
using Domain.Entities.EventManagement.Users;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infraestructure.Services
{
    public class JWTTokenService : ITokenService
    {
        private readonly JWTSettings _settings;

        public JWTTokenService(IOptions<JWTSettings> settings)
        {
            _settings = settings.Value;
        }

        public string CreateToken(User user, IList<string> roles, TokenType tokenType, TokenDurationType? durationType = null, int? duration = null)
        {
            var claims = new List<Claim>()
            {
                new(JwtRegisteredClaimNames.Name, user.Username),
                new("userId", usuario.Id),
                new("email", usuario.Email)
            };

            foreach (var rol in roles)
            {
                var claim = new Claim(ClaimTypes.Role, rol);
                claims.Add(claim);
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Key!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(10),//_settings.ExpireTime),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescription);

            return tokenHandler.WriteToken(token);
        }
    }
}

using Application.Contracts.Services;
using Application.Enums;
using Application.Models.Settings;
using Domain.Entities.EventManagement.Users;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


/*
 Por el momento solo se trabajará con los ACCESS y los REFRESH tokens
 */
namespace Infraestructure.Services
{
    public class JWTTokenService : ITokenService
    {
        private readonly JWTSettings _settings;

        public JWTTokenService(IOptions<JWTSettings> settings)
        {
            _settings = settings.Value ?? throw new ArgumentNullException(nameof(settings));
        }

        public string CreateToken(User user, IList<string> roles, TokenType tokenType)
        {
            if (string.IsNullOrEmpty(_settings.Key))
                throw new ArgumentNullException("JWT Key is not configured properly.");

            var claims = BuildClaims(user, roles, tokenType);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Key!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = credentials,
                Expires = SetTokenExpiration(tokenType)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(token);
        }

        public string CreateToken(User user, IList<string> roles, TokenDurationType durationType, int duration)
        {
            var claims = BuildClaims(user, roles);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Key!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = credentials,
                Expires = SetDurationToken(durationType, duration)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(token);
        }

        private IList<Claim> BuildClaims(User user, IList<string> roles, TokenType? tokenType = null)
        {
            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Name, user.Username),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            if (tokenType.HasValue)
            {
                claims.Add(new Claim("TokenType", tokenType.Value.ToString()));
            }

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private DateTime? SetTokenExpiration(TokenType tokenType)
        {
            return tokenType switch
            {
                TokenType.Access => DateTime.UtcNow.AddMinutes(15),
                TokenType.Refresh => DateTime.UtcNow.AddDays(30),
                TokenType.Unique => DateTime.UtcNow.AddHours(1),
                _ => null
            };
        }

        private DateTime SetDurationToken(TokenDurationType durationType, int duration)
        {
            var durationMapper = new Dictionary<TokenDurationType, Func<int, DateTime>>
            {
                { TokenDurationType.Minutes, x => DateTime.UtcNow.AddMinutes(x) },
                { TokenDurationType.Hours, x => DateTime.UtcNow.AddHours(x) },
                { TokenDurationType.Days, x => DateTime.UtcNow.AddDays(x) },
                { TokenDurationType.Months, x => DateTime.UtcNow.AddMonths(x) },
                { TokenDurationType.Years, x => DateTime.UtcNow.AddYears(x) },
            };

            if (!durationMapper.ContainsKey(durationType))
                throw new ArgumentException("Invalid duration type", nameof(durationType));

            return durationMapper[durationType](duration);
        }
    }
}



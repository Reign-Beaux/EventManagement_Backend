using Application.Enums;
using Domain.Entities.EventManagement.Users;

namespace Application.Contracts.Services
{
    public interface ITokenService
    {
        string CreateToken(User user, IList<string> roles, TokenType tokenType);
        public string CreateToken(User user, IList<string> roles, TokenDurationType durationType, int duration);
    }
}

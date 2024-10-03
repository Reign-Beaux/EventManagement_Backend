using Domain.Entities.EventManagement.Users;

namespace Application.Contracts.Services
{
    public interface ITokenService
    {
        string CreateToken(User user, IList<string> roles, int duration, string typeDuration);
    }
}

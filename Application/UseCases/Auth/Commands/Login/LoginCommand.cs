using Domain.ValueObjects;

namespace Application.UseCases.Auth.Commands.Login
{
    public record LoginCommand(string UsernameOrEmail, Password Password) : IRequest<ErrorOr<string>>;
}

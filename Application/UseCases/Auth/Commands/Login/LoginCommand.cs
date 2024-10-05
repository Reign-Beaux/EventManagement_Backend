namespace Application.UseCases.Auth.Commands.Login
{
    public record LoginCommand(string UsernameOrEmail, string Password) : IRequest<ErrorOr<string>>;
}

namespace Application.UseCases.Users.Commands.UserUpdate
{
    public record UserUpdateCommand(
        Guid Id,
        Guid UserTypeId,
        string Username,
        string Email,
        string Password,
        string PasswordConfirm) : IRequest<ErrorOr<Unit>>;
}

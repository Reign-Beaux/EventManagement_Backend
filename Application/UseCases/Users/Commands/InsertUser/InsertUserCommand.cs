namespace Application.UseCases.Users.Commands.InsertUser
{
    public record InsertUserCommand(
        Guid UserTypeId,
        string Username,
        string Email,
        string Password,
        string PasswordConfirm) : IRequest<ErrorOr<Unit>>;
}

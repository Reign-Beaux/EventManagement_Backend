namespace Application.UseCases.Users.Commands.UserInsert
{
    public record UserInsertCommand(
        Guid UserTypeId,
        string Username,
        string Email,
        string Password,
        string PasswordConfirm) : IRequest<ErrorOr<Unit>>;
}

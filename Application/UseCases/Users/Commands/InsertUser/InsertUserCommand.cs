using Domain.ValueObjects;

namespace Application.UseCases.Users.Commands.InsertUser
{
    public record InsertUserCommand(
        Guid UserTypeId,
        Username Username,
        Email Email,
        Password Password,
        Guid CreatedBy) : IRequest<ErrorOr<Unit>>;
}

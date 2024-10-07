using Domain.Entities.EventManagement.Users;

namespace Application.UseCases.Users.Queries.UserGetById
{
    public record UserGetByIdQuery(Guid Id) : IRequest<ErrorOr<User>>;
}

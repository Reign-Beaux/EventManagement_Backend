using Domain.Entities.EventManagement.Users;

namespace Application.UseCases.Users.Queries.UserGetAll
{
    public record UserGetAllQuery() : IRequest<ErrorOr<IReadOnlyList<User>>>;
}

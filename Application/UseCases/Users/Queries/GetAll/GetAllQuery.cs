using Domain.Entities.EventManagement.Users;

namespace Application.UseCases.Users.Queries.GetAll
{
    public record GetAllQuery() : IRequest<ErrorOr<IReadOnlyList<User>>>;
}

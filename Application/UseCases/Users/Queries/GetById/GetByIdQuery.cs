using Domain.Entities.EventManagement.Users;

namespace Application.UseCases.Users.Queries.GetById
{
    public record GetByIdQuery(Guid Id) : IRequest<ErrorOr<User>>;
}

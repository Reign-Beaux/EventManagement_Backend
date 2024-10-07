using Domain.Entities.EventManagement.Users;
using Domain.UnitOfWork;

namespace Application.UseCases.Users.Queries.UserGetAll
{
    public class UserGetAllQueryHandler(IEventManagementUnitOfWork eventManagement) : IRequestHandler<UserGetAllQuery, ErrorOr<IReadOnlyList<User>>>
    {
        private readonly IEventManagementUnitOfWork _eventManagement = eventManagement;

        public async Task<ErrorOr<IReadOnlyList<User>>> Handle(UserGetAllQuery request, CancellationToken cancellationToken)
        {
            List<User> response = await _eventManagement.UsersRepository.GetAll();
            return response;
        }
    }
}

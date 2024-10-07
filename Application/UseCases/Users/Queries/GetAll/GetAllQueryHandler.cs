using Domain.Entities.EventManagement.Users;
using Domain.UnitOfWork;

namespace Application.UseCases.Users.Queries.GetAll
{
    public class GetAllQueryHandler(IEventManagementUnitOfWork eventManagement) : IRequestHandler<GetAllQuery, ErrorOr<IReadOnlyList<User>>>
    {
        private readonly IEventManagementUnitOfWork _eventManagement = eventManagement;

        public async Task<ErrorOr<IReadOnlyList<User>>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            List<User> response = await _eventManagement.UsersRepository.GetAll();
            return response;
        }
    }
}

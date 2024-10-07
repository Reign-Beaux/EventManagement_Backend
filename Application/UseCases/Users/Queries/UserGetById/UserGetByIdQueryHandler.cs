using Application.Interfaces.Adapters;
using Application.UseCases.Auth.Commands.Login;
using Domain.Entities.EventManagement.Users;
using Domain.UnitOfWork;

namespace Application.UseCases.Users.Queries.UserGetById
{
    public class UserGetByIdQueryHandler(IEventManagementUnitOfWork eventManagement, IErrorAdapter error) : IRequestHandler<UserGetByIdQuery, ErrorOr<User>>
    {
        private readonly IEventManagementUnitOfWork _eventManagement = eventManagement;
        private readonly IErrorAdapter _error = error;

        public async Task<ErrorOr<User>> Handle(UserGetByIdQuery request, CancellationToken cancellationToken)
        {
            User? user = await _eventManagement.UsersRepository.GetById(request.Id);

            if (user is null)
                return _error.NotFound<LoginCommand>(UserErrors.NotFound.Id, nameof(request.Id));

            return user;
        }
    }
}

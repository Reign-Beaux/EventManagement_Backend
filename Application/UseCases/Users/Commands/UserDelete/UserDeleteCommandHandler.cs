using Application.Interfaces.Adapters;
using Application.UseCases.Users.Commands.UserUpdate;
using Domain.Entities.EventManagement.Users;
using Domain.UnitOfWork;

namespace Application.UseCases.Users.Commands.UserDelete
{
    public class UserDeleteCommandHandler(IEventManagementUnitOfWork eventManagement, IErrorAdapter error) : IRequestHandler<UserDeleteCommand, ErrorOr<Unit>>
    {
        private readonly IEventManagementUnitOfWork _eventManagement = eventManagement;
        private readonly IErrorAdapter _error = error;

        public async Task<ErrorOr<Unit>> Handle(UserDeleteCommand request, CancellationToken cancellationToken)
        {
            User? user = await _eventManagement.UsersRepository.GetById(request.Id);

            if (user is not null)
                return _error.NotFound<UserUpdateCommand>(UserErrors.NotFound.Id, nameof(request.Id));

            await _eventManagement.UsersRepository.Delete(request.Id);
            _eventManagement.Commit();

            return Unit.Value;
        }
    }
}

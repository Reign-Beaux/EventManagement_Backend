
using Domain.UnitOfWork;

namespace Application.UseCases.Users.Commands.InsertUser
{
    public class InsertUserCommandHandler(
        IEventManagementUnitOfWork eventManagement) : IRequestHandler<InsertUserCommand, ErrorOr<Unit>>
    {
        private readonly IEventManagementUnitOfWork _eventManagement = eventManagement;

        public async Task<ErrorOr<Unit>> Handle(InsertUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

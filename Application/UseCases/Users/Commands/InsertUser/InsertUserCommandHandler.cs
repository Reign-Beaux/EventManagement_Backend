using Application.Interfaces.Adapters;
using Application.UseCases.Auth.Commands.Login;
using Domain.Entities.EventManagement.Users;
using Domain.UnitOfWork;
using Domain.ValueObjects;

namespace Application.UseCases.Users.Commands.InsertUser
{
    public class InsertUserCommandHandler(IEventManagementUnitOfWork eventManagement, IErrorAdapter error) : IRequestHandler<InsertUserCommand, ErrorOr<Unit>>
    {
        private readonly IEventManagementUnitOfWork _eventManagement = eventManagement;
        private readonly IErrorAdapter _error = error;

        public async Task<ErrorOr<Unit>> Handle(InsertUserCommand request, CancellationToken cancellationToken)
        {
            if (Username.Create(request.Username) is not Username username)
                return _error.Validation<LoginCommand>(UserErrors.Format.Username, nameof(request.Username));

            if (Email.Create(request.Email) is not Email email)
                return _error.Validation<LoginCommand>(UserErrors.Format.Email, nameof(request.Email));

            if (Email.Create(request.Password) is not Email password)
                return _error.Validation<LoginCommand>(UserErrors.Format.Password, nameof(request.Password));


        }
    }
}

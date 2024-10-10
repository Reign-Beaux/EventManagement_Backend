using Application.Interfaces.Adapters;
using Domain.Entities.EventManagement.Users;
using Domain.Entities.EventManagement.Users.Repository.Parameters;
using Domain.UnitOfWork;

namespace Application.UseCases.Users.Commands.UserUpdate
{
    public class UserUpdateCommandHandler(
        IEventManagementUnitOfWork eventManagement,
        IEncryptionAdapter encryption,
        IErrorAdapter error) : IRequestHandler<UserUpdateCommand, ErrorOr<Unit>>
    {
        private readonly IEventManagementUnitOfWork _eventManagement = eventManagement;
        private readonly IEncryptionAdapter _encryption = encryption;
        private readonly IErrorAdapter _error = error;

        public async Task<ErrorOr<Unit>> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
        {
            User? user = await _eventManagement.UsersRepository.GetById(request.Id);

            if (user is null)
                return _error.NotFound<UserUpdateCommand>(UserErrors.NotFound.Id, nameof(request.Id));

            string passwordHash = _encryption.HashText(request.Password);

            UserUpdateParameters parameters = new()
            {
                Id = request.Id,
                UserTypeId = request.UserTypeId,
                Username = request.Username,
                Email = request.Email,
                PasswordHash = passwordHash,
                UpdatedBy = Guid.Parse("3BF8D2C7-6C42-4434-912F-98FACF6F5EAE"),
            };

            await _eventManagement.UsersRepository.Update(parameters);
            _eventManagement.Commit();

            return Unit.Value;
        }
    }
}

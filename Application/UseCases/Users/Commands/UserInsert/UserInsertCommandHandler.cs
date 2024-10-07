using Application.Interfaces.Adapters;
using Domain.Entities.EventManagement.Users.Repository.Parameters;
using Domain.UnitOfWork;

namespace Application.UseCases.Users.Commands.UserInsert
{
    public class UserInsertCommandHandler(
        IEventManagementUnitOfWork eventManagement,
        IEncryptionAdapter encryption) : IRequestHandler<UserInsertCommand, ErrorOr<Unit>>
    {
        private readonly IEventManagementUnitOfWork _eventManagement = eventManagement;
        private readonly IEncryptionAdapter _encryption = encryption;

        public async Task<ErrorOr<Unit>> Handle(UserInsertCommand request, CancellationToken cancellationToken)
        {
            string passwordHash = _encryption.HashText(request.Password);

            UserInsertParameters parameters = new()
            {
                UserTypeId = request.UserTypeId,
                Username = request.Username,
                Email = request.Email,
                PasswordHash = passwordHash,
                CreatedBy = Guid.Parse("A2CC6B7D-EE88-4331-9D4C-E5A88C8BF992"),
            };

            await _eventManagement.UsersRepository.Insert(parameters);
            _eventManagement.Commit();

            return Unit.Value;
        }
    }
}

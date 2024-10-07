using Application.Interfaces.Adapters;
using Application.Interfaces.Services;
using Domain.Entities.EventManagement.Users;
using Domain.UnitOfWork;
using Domain.ValueObjects;

namespace Application.UseCases.Auth.Commands.Login
{
    public class LoginCommandHandler(
        IEventManagementUnitOfWork eventManagement,
        IEncryptionAdapter encryption,
        ITokenService token,
        IErrorAdapter error) : IRequestHandler<LoginCommand, ErrorOr<string>>
    {
        private readonly IEventManagementUnitOfWork _eventManagement = eventManagement;
        private readonly IEncryptionAdapter _encryption = encryption;
        private readonly ITokenService _token = token;
        private readonly IErrorAdapter _error = error;

        public async Task<ErrorOr<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            User? user;
            if (request.UsernameOrEmail.Contains('@'))
            {
                if (Email.Create(request.UsernameOrEmail) is not Email email)
                    return _error.Validation<LoginCommand>(UserErrors.Format.Email, nameof(request.UsernameOrEmail));

                user = await _eventManagement.UsersRepository.GetByEmail(email.Value);
                if (user is null)
                    return _error.NotFound<LoginCommand>(UserErrors.NotFound.Email, nameof(request.UsernameOrEmail));
            }
            else
            {
                if (Username.Create(request.UsernameOrEmail) is not Username username)
                    return _error.Validation<LoginCommand>(UserErrors.Format.Username, nameof(request.UsernameOrEmail));

                user = await _eventManagement.UsersRepository.GetByUsername(username.Value);
                if (user is null)
                    return _error.NotFound<LoginCommand>(UserErrors.NotFound.Email, nameof(request.UsernameOrEmail));
            }

            if (!_encryption.VerifyText(user.PasswordHash, request.Password.Value))
            {
                return _error.Validation<LoginCommand>(UserErrors.BadContent.Password, nameof(request.Password));
            }

            /*
             * Falta obtener la lista de Roles
             * Falta Generar el refresh Token
             */

            return _token.CreateToken(user, [], Enums.TokenType.Access);
        }
    }
}

using Application.Contracts.Adapters;
using Application.Contracts.Services;
using Domain.Entities.EventManagement.Users;
using Domain.UnitOfWork;

namespace Application.UseCases.Auth.Commands.Login
{
    public class LoginCommandHandler(IEventManagementUnitOfWork eventManagement, IEncryptionAdapter encryptionAdapter, ITokenService tokenService) : IRequestHandler<LoginCommand, ErrorOr<string>>
    {
        private readonly IEventManagementUnitOfWork _eventManagement = eventManagement;
        private readonly IEncryptionAdapter _encryptionAdapter = encryptionAdapter;
        private readonly ITokenService _tokenService = tokenService;

        public async Task<ErrorOr<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            User? user;
            if (request.UsernameOrEmail.Contains('@'))
            {
                user = await _eventManagement.UsersRepository.GetByEmail(request.UsernameOrEmail);
                if (user is null) 
                    return Error.NotFound(UserErrors.GetCodeError(nameof(UserErrors.NotFoundByEmail)), UserErrors.NotFoundByEmail);
            }
            else
            {
                user = await _eventManagement.UsersRepository.GetByUsername(request.UsernameOrEmail);
                if (user is null)
                    return Error.NotFound(UserErrors.GetCodeError(nameof(UserErrors.NotFoundByUsername)), UserErrors.NotFoundByUsername);
            }

            if (!_encryptionAdapter.VerifyText(user.PasswordHash, request.Password))
            {
                return Error.NotFound(UserErrors.GetCodeError(nameof(UserErrors.IncorrectPassword)), UserErrors.IncorrectPassword);
            }

            /*
             * Falta obtener la lista de Roles
             * Falta Generar el refresh Token
             */

            return _tokenService.CreateToken(user, [], Enums.TokenType.Access);
        }
    }
}

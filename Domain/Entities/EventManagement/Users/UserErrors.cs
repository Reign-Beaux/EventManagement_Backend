using Domain.Abstractions;

namespace Domain.Entities.EventManagement.Users
{
    public sealed class UserErrors : ErrorsAbstraction<UserErrors>
    {
        public const string NotFoundByUsername = "El nombre de usuario no fue encontrado.";
        public const string NotFoundByEmail = "El correo electrónico no fue encontrado.";
        public const string IncorrectPassword = "La contraseña es incorrecta.";
    }
}

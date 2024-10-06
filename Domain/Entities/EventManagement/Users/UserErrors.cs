using Domain.Abstractions;

namespace Domain.Entities.EventManagement.Users
{
    public sealed class UserErrors
    {
        public static class Format
        {
            public const string Email = "El correo electrónico tiene un formato incorrecto.";
            public const string Username = "El nombre de usuario tiene un formato incorrecto.";
            public const string Password = "La contraseña tiene un formato incorrecto.";
        }

        public static class NotFound
        {
            public const string Email = "El correo electrónico no fue encontrado.";
            public const string Username = "El nombre de usuario no fue encontrado.";
        }

        public static class Auth
        {
            public const string Password = "La contraseña es incorrecta.";
        }
    }
}

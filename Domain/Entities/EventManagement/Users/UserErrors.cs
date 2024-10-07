namespace Domain.Entities.EventManagement.Users
{
    public static class UserErrors
    {
        public static class BadContent
        {
            public const string Password = "La contraseña es incorrecta.";
            public const string PasswordConfirmed = "La contraseña y la confirmación de la contraseña no coinciden.";
        }

        public static class Required
        {
            public const string UserTypeId = "El tipo de usuario es requerido.";
            public const string Username = "El usuario es requerido.";
            public const string Email = "El correo electrónico es requerido.";
            public const string Password = "La contraseña es requerida.";
            public const string PasswordConfirmed = "La confirmación de la contraseña es requerida.";
        }

        public static class Format
        {
            public const string Email = "El correo electrónico tiene un formato incorrecto.";
            public const string Username = "El nombre de usuario tiene un formato incorrecto.";
            public const string Password = "La contraseña tiene un formato incorrecto.";
        }

        public static class NotFound
        {
            public const string Email = "El correo electrónico no fue encontrado.";
            public const string Id = "El usuario no fue encontrado.";
            public const string Username = "El nombre de usuario no fue encontrado.";
        }
    }
}

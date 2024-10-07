using System.Text.RegularExpressions;

namespace Domain.Entities.EventManagement.Users
{
    public static partial class UserRegexes
    {
        public static readonly Regex Email = EmailRegex();
        public static readonly Regex Password = PasswordRegex();
        public static readonly Regex Username = UsernameRegex();

        [GeneratedRegex(@"^[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?$")]
        private static partial Regex EmailRegex();

        [GeneratedRegex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[$%&@#])[A-Za-z\d$%&@#]{8,36}$")]
        private static partial Regex PasswordRegex();

        [GeneratedRegex(@"^[A-Za-z\d._-]{4,32}$")]
        private static partial Regex UsernameRegex();
    }
}

using System.Text.RegularExpressions;

namespace Domain.ValueObjects
{
    public partial class Password
    {
        private const string Pattern = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[$%&@#])[A-Za-z\d$%&@#]{8,36}$";

        public string Value { get; }

        [GeneratedRegex(Pattern)]
        private static partial Regex PasswordRegex();

        private Password(string value)
            => Value = value;

        public static Password? Create(string value)
        {
            if (string.IsNullOrEmpty(value) || !PasswordRegex().IsMatch(value))
                return null;

            return new Password(value);
        }
    }
}

using System.Text.RegularExpressions;

namespace Domain.ValueObjects
{
    public partial class Email
    {
        private const string Pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

        public string Value { get; }

        [GeneratedRegex(Pattern)]
        private static partial Regex EmailRegex();

        private Email(string value)
            => Value = value;

        public static Email? Create(string value)
        {
            if (string.IsNullOrEmpty(value) || !EmailRegex().IsMatch(value))
                return null;

            return new Email(value);
        }
    }
}

using System.Text.RegularExpressions;

namespace Domain.ValueObjects
{
    public partial class Username
    {
        private const string Pattern = @"^[A-Za-z\d._-]{4,32}$";

        public string Value { get; }

        [GeneratedRegex(Pattern)]
        private static partial Regex UsernameRegex();

        private Username(string value)
            => Value = value;

        public static Username? Create(string value)
        {
            if (string.IsNullOrEmpty(value) || !UsernameRegex().IsMatch(value))
                return null;

            return new Username(value);
        }
    }
}

using Domain.Adapters;
using BC = BCrypt.Net.BCrypt;

namespace Infraestructure.Adapters
{
    public class BCryptAdapter : IEncryptionAdapter
    {
        public string HashText(string text)
            => BC.HashPassword(text);

        public bool VerifyText(string text, string hashed)
            => BC.Verify(text, hashed);
    }
}

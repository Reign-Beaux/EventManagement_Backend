﻿namespace Domain.Adapters
{
    public interface IEncryptionAdapter
    {
        string HashText(string text);
        bool VerifyText(string text, string hashed);
    }
}

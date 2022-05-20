using Isopoh.Cryptography.Argon2;
using PAdmin.Core.Business;

namespace PAdmin.Business;

public class PasswordHashService : IPasswordHashService
{
    public async Task<string> HashPassword(string password)
    {
        return Argon2.Hash(password);
    }

    public async Task<bool> ComparePassword(string password, string hash)
    {
        return Argon2.Verify(hash, password, 2);
    }
}
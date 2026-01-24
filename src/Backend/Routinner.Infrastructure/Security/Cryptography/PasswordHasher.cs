using Routinner.Domain.Security.Cryptography;
using BC = BCrypt.Net.BCrypt;

namespace Routinner.Infrastructure.Security.Cryptography;

internal class PasswordHasher : IPasswordHasher
{
    public string Hash(string password) => BC.HashPassword(password);
}

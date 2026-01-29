using Routinner.Domain.Security.Cryptography;
using System.Runtime.CompilerServices;
using BC = BCrypt.Net.BCrypt;

[assembly: InternalsVisibleTo("CommonTestUtilities")]
namespace Routinner.Infrastructure.Security.Cryptography;

internal class PasswordHasher : IPasswordHasher
{
    public string Hash(string password) => BC.HashPassword(password);
}

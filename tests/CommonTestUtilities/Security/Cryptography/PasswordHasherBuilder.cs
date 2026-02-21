using Routinner.Domain.Security.Cryptography;
using Routinner.Infrastructure.Security.Cryptography;

namespace CommonTestUtilities.Security.Cryptography;

public static class PasswordHasherBuilder
{
    public static IPasswordHasher Build() => new PasswordHasher();
}

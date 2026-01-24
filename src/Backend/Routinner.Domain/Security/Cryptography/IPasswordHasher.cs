namespace Routinner.Domain.Security.Cryptography;

public interface IPasswordHasher
{
    public string Hash(string password);
}

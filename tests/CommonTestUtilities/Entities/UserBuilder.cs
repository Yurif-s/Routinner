using Bogus;
using CommonTestUtilities.Security.Cryptography;
using Routinner.Domain.Entities;

namespace CommonTestUtilities.Entities;

public static class UserBuilder
{
    public static User Build(int passwordLenght = 8)
    {
        var passwordhasher = PasswordHasherBuilder.Build();

        var password = new Faker().Internet.Password(passwordLenght);

        return new Faker<User>()
            .RuleFor(user => user.Id, f => f.Random.Number(min: 1))
            .RuleFor(user => user.Name, f => f.Person.FirstName)
            .RuleFor(u => u.Email, (f, user) => f.Internet.Email(user.Name))
            .RuleFor(u => u.Password, f => passwordhasher.Hash(password));
    }
}

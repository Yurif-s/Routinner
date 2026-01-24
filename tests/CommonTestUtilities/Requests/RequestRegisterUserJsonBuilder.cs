using Bogus;
using Routinner.Communication.Requests;

namespace CommonTestUtilities.Requests;

public static class RequestRegisterUserJsonBuilder
{
    public static RequestRegisterUserJson Build(int passwordLenght)
    {
        return new Faker<RequestRegisterUserJson>()
            .RuleFor(user => user.Name, f => f.Person.FirstName)
            .RuleFor(u => u.Name, (f, user) => f.Internet.Email(user.Name))
            .RuleFor(u => u.Password, f => f.Internet.Password(passwordLenght))
    }
}

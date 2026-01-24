using Bogus;
using Routinner.Communication.Requests;

namespace CommonTestUtilities.Requests;

public static class RequestRegisterUserJsonBuilder
{
    public static RequestRegisterUserJson Build(int passwordLenght = 10)
    {
        return new Faker<RequestRegisterUserJson>()
            .RuleFor(user => user.Name, f => f.Person.FirstName)
            .RuleFor(u => u.Email, (f, user) => f.Internet.Email(user.Name))
            .RuleFor(u => u.Password, f => f.Internet.Password(passwordLenght));
    }
}

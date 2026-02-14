using Bogus;
using Routinner.Communication.Requests;

namespace CommonTestUtilities.Requests;

public static class RequestRegisterRoutineJsonBuilder
{
    public static RequestRegisterRoutineJson Build()
    {
        return new Faker<RequestRegisterRoutineJson>()
            .RuleFor(routine => routine.Name, f => f.Lorem.Word())
            .RuleFor(r => r.StartDate, f => DateOnly.FromDateTime(f.Date.Future()))
            .RuleFor(r => r.EndDate, (f, r) =>
                DateOnly.FromDateTime(f.Date.Future(refDate: r.StartDate.ToDateTime(TimeOnly.MinValue))));
    }
}

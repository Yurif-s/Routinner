using CommonTestUtilities.Requests;
using Routinner.Application.UseCases.Routine.Register;
using Routinner.Exception;
using Shouldly;

namespace Validators.Test.Routine.Register;

public class RegisterRoutineValidatorTest
{
    [Fact]
    public void Sucess()
    {
        var request = RequestRegisterRoutineJsonBuilder.Build();
        var validator = new RegisterRoutineValidator();

        var result = validator.Validate(request);

        result.IsValid.ShouldBeTrue();
    }
    [Fact]
    public void Error_Name_Empty()
    {
        var request = RequestRegisterRoutineJsonBuilder.Build();
        var validator = new RegisterRoutineValidator();
        request.Name = string.Empty;

        var result = validator.Validate(request);

        result.IsValid.ShouldBeFalse();
        result.Errors.ShouldSatisfyAllConditions(errors =>
        {
            errors.ShouldHaveSingleItem();
            errors.ShouldContain(e => e.ErrorMessage.Equals(ResourceMessagesException.NAME_EMPTY));
        });
    }
    [Fact]
    public void Error_Start_Date_Cannot_Past()
    {
        var request = RequestRegisterRoutineJsonBuilder.Build();
        var validator = new RegisterRoutineValidator();
        request.StartDate = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(-1));

        var result = validator.Validate(request);

        result.IsValid.ShouldBeFalse();
        result.Errors.ShouldSatisfyAllConditions(errors =>
        {
            errors.ShouldHaveSingleItem();
            errors.ShouldContain(e => e.ErrorMessage.Equals(ResourceMessagesException.START_DATE_CANNOT_PAST));
        });
    }
    [Fact]
    public void Error_End_Date_Must_Greather_Start_Date()
    {
        var request = RequestRegisterRoutineJsonBuilder.Build();
        var validator = new RegisterRoutineValidator();
        request.EndDate = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(-1)); ;

        var result = validator.Validate(request);

        result.IsValid.ShouldBeFalse();
        result.Errors.ShouldSatisfyAllConditions(errors =>
        {
            errors.ShouldHaveSingleItem();
            errors.ShouldContain(e => e.ErrorMessage.Equals(ResourceMessagesException.END_DATE_GREATHER_START_DATE));
        });
    }
}

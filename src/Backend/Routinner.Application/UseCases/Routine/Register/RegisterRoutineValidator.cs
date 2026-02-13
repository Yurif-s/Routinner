using FluentValidation;
using Routinner.Communication.Requests;
using Routinner.Exception;

namespace Routinner.Application.UseCases.Routine.Register;

public class RegisterRoutineValidator : AbstractValidator<RequestRegisterRoutineJson>
{
    public RegisterRoutineValidator()
    {
        RuleFor(r => r.Name).NotEmpty().WithMessage(ResourceMessagesException.NAME_EMPTY);
        RuleFor(r => r.StartDate).NotEmpty().WithMessage(ResourceMessagesException.START_DATE_INVALID);
        RuleFor(r => r.EndDate).NotEmpty().WithMessage(ResourceMessagesException.END_DATE_INVALID);
        
        When(r => !string.IsNullOrEmpty(r.StartDate.ToString()), () =>
        {
            RuleFor(r => r.StartDate).GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.UtcNow)).WithMessage(ResourceMessagesException.START_DATE_CANNOT_PAST);
        });
        When(r => !string.IsNullOrEmpty(r.EndDate.ToString()), () =>
        {
            RuleFor(r => r).Must(r => r.EndDate > r.StartDate).WithMessage(ResourceMessagesException.END_DATE_GREATHER_START_DATE);
        });
    }
}

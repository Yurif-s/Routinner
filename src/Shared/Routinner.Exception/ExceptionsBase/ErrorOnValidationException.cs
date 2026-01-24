using System.Net;

namespace Routinner.Exception.ExceptionsBase;

public class ErrorOnValidationException : RoutinnerException
{
    private readonly IList<string> _errors;
    public ErrorOnValidationException(IList<string> errors) : base(string.Empty)
    {
        _errors = errors;   
    }

    public override int StatusCode => (int)HttpStatusCode.BadRequest;

    public override IList<string> GetErrors() => _errors;
}

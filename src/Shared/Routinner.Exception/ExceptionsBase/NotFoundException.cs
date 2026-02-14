using System.Net;

namespace Routinner.Exception.ExceptionsBase;

public class NotFoundException : RoutinnerException
{
    public NotFoundException(string message) : base(message)
    {
    }

    public override int StatusCode => (int)HttpStatusCode.NotFound;

    public override IList<string> GetErrors() => [Message];
}

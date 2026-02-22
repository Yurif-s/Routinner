namespace Routinner.Exception.ExceptionsBase;

public abstract class RoutinnerException : SystemException
{
    protected RoutinnerException(string message) : base(message) 
    { }

    public abstract int StatusCode { get; }
    public abstract IList<string> GetErrors();
}

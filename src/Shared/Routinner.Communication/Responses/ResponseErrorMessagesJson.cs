namespace Routinner.Communication.Responses;

public class ResponseErrorMessagesJson
{
    public IList<string> _errors;
    public ResponseErrorMessagesJson(IList<string> errors) => _errors = errors;
    public ResponseErrorMessagesJson(string error) => _errors = [error];
}

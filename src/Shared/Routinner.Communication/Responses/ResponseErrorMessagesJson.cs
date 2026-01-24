namespace Routinner.Communication.Responses;

public class ResponseErrorMessagesJson
{
    public IList<string> Errors { get; set; }
    public ResponseErrorMessagesJson(IList<string> errors) => Errors = errors;
    public ResponseErrorMessagesJson(string error) => Errors = [error];
}

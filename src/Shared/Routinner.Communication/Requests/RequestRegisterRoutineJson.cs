namespace Routinner.Communication.Requests;

public class RequestRegisterRoutineJson
{
    public string Name { get; set; } = string.Empty;
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public long UserId { get; set; }
}

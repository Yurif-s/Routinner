namespace Routinner.Domain.Entities;

public class Routine : EntityBase
{
    public string Name { get; set; } = string.Empty;
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public long UserId { get; set; }
}

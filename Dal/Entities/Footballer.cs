using Dal.Enums;

namespace Dal.Entities;

public class Footballer
{
    public long Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public Gender Gender { get; set; }
    
    public DateOnly Birthday { get; set; }
    
    public Team Team { get; set; }

    public Country Country { get; set; }
}
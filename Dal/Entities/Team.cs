using System.Security.AccessControl;

namespace Dal.Entities;

public class Team
{
    public long Id { get; set; }
    
    public string Name { get; set; }
    
    public List<Footballer> Footballers { get; set; }
}
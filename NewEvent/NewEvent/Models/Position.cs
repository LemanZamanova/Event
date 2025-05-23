namespace NewEvent.Models;

public class Position:BaseEntity
{
    public string Name { get; set; }
    //relation
    public List<Speaker> Speakers { get; set; }
}

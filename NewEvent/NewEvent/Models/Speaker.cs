namespace NewEvent.Models;

public class Speaker:BaseEntity
{
    public string Image { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    //relations
    public int PositionId { get; set; }
    public Position Position { get; set; }
}

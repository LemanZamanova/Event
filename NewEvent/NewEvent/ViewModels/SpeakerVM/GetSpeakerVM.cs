namespace NewEvent.ViewModels;

public class GetSpeakerVM
{
    public int Id { get; set; }
    public string Image { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    //relations
    public int PositionId { get; set; }
    public string PositionName { get; set; }
}

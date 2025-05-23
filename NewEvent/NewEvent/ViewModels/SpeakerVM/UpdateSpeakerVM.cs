

using NewEvent.Models;
using System.ComponentModel.DataAnnotations;

namespace NewEvent.ViewModels;

public class UpdateSpeakerVM
{
    public int Id { get; set; }
    
    public string Image { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    //relations
    [Required]
    public int? PositionId { get; set; }
    public List<Position> Position { get; set; }
}

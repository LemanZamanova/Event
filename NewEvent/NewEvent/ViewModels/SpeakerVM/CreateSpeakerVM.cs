

using NewEvent.Models;
using System.ComponentModel.DataAnnotations;

namespace NewEvent.ViewModels;

public class CreateSpeakerVM
{
    public string Image { get; set; }
    [MinLength(3)]
    public string Name { get; set; }
    [MinLength(5)]
    public string Surname { get; set; }
    //relations
    public IFormFile Photo { get; set; }
    public int PositionId { get; set; }
    public List<Position> Position { get; set; }
}

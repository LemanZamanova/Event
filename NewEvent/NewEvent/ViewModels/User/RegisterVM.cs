using System.ComponentModel.DataAnnotations;

namespace NewEvent.ViewModels.User;

public class RegisterVM
{
    [MinLength(3)]
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    [DataType(nameof(Password))]
    public string Password { get; set; }
    [DataType(nameof(Password))]
    //[Compare(Password)]
    public string ConfirmPassword { get; set; }
}

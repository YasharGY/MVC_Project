
using System.ComponentModel.DataAnnotations;

namespace EduApp.Areas.EduAdmin.ViewModels.RegisterViewModel;

public class LoginVM
{
    [Required,DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    [Required,DataType(DataType.Password)]
    public string Password { get; set; }
    public bool RememberMe { get; set; }
}

using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EduApp.ViewModels;

public class FotgotPasswordVM
{
    [Required, EmailAddress, Display(Name = "Registed Email Address")]
    public string Email { get; set; }
}

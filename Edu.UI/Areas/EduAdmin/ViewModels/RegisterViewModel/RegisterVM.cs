﻿
using System.ComponentModel.DataAnnotations;

namespace EduApp.Areas.EduAdmin.ViewModels.RegisterViewModel;

public class RegisterVM
{
    [Required]
    public string Fullname { get; set; }
    [Required]
    public string UserName { get; set; }
    [Required, DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    [Required, DataType(DataType.Password)]
    public string Password { get; set; }
    [Required, DataType(DataType.Password), Compare(nameof(Password))]
    public string ConfirmPassword { get; set; }


}

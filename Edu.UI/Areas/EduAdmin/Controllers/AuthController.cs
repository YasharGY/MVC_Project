using Edu.Core.Entities;
using EduApp.Areas.EduAdmin.ViewModels.RegisterViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EduApp.Areas.EduAdmin.Controllers;
[Area("EduAdmin")]
public class AuthController : Controller
{
    private readonly UserManager<AppUser> _userManager;

    public AuthController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public IActionResult Register()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterVM newuser)
    {
        if (!ModelState.IsValid) return View(newuser);
        AppUser user = new()
        {
            Fullname = newuser.Fullname,
            UserName = newuser.UserName,
            Email = newuser.Email,

        };
        IdentityResult result= await _userManager.AddPasswordAsync(user,newuser.Password);
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(newuser);
        }
        return Ok();
    }
}

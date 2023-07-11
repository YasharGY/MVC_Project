using Edu.Core.Entities;
using EduApp.Areas.EduAdmin.ViewModels.RegisterViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EduApp.Areas.EduAdmin.Controllers;
[Area("EduAdmin")]
public class AuthController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
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

        IdentityResult result = await _userManager.CreateAsync(user, newuser.Password);
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(newuser);
        }
        return RedirectToAction("Login");
    }
    
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginVM login)
    {
        if (!ModelState.IsValid) return View(login);
        AppUser user = await _userManager.FindByEmailAsync(login.Email);
        if (user == null)
        {
            ModelState.AddModelError("", "Invalid Login!");
            return View(login);
        }
        Microsoft.AspNetCore.Identity.SignInResult signInResult =
        await _signInManager.PasswordSignInAsync(user, login.Password, login.RememberMe, true);
        if (!signInResult.IsLockedOut)
        {
            ModelState.AddModelError("", " Your account is locked. Try after!");
            return View(login);
        }
        
        
        if (!signInResult.Succeeded)
        {
            ModelState.AddModelError("", "Invalid Login!");
            return View(login);
        }
        
        return RedirectToAction("Index","Home");
    }

    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index","Home");
    }
}

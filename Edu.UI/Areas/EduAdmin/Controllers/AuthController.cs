using Edu.Core.Entities;
using EduApp.Areas.EduAdmin.Data.Service;
using EduApp.Areas.EduAdmin.ViewModels.RegisterViewModel;
using EduApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EduApp.Areas.EduAdmin.Controllers;
[Area("EduAdmin")]

public class AuthController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IWebHostEnvironment _env;
    private readonly IEmailService _emailService;
    public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IEmailService emailService, IWebHostEnvironment env)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _emailService = emailService;
        _env = env;
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
        if (signInResult.IsLockedOut)
        {
            ModelState.AddModelError("", " Your account is locked. Try after!");
            return View(login);
        }
        
        
        if (!signInResult.Succeeded)
        {
            ModelState.AddModelError("", "Invalid Login!");
            return View(login);
        }
        
        return RedirectToAction("Index","Home", new { area = string.Empty });
    }

    public async Task<IActionResult> Logout()
    {
        if (User.Identity.IsAuthenticated)
        {
			await _signInManager.SignOutAsync();
		}
       
        return RedirectToAction("Index","Home", new {area = string.Empty});
    }



    public async Task<IActionResult> ConfirmEmail(string token, string email)
    {
        if (token is null || email is null) return BadRequest();

        AppUser user = await _userManager.FindByEmailAsync(email);
        if (user is null) return NotFound();

        await _userManager.ConfirmEmailAsync(user, token);
        await _signInManager.SignInAsync(user, false);

        return RedirectToAction("Index", "Home");
    }

    public IActionResult ForgotPasswordConfirm()
    {
        return View();
    }


    public IActionResult ResetPasswordConfirm()
    {
        return View();
    }

    public IActionResult ForgetPassword()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ForgetPassword(FotgotPasswordVM forgotPasswordModel)
    {
        if (!ModelState.IsValid) return View(forgotPasswordModel);

        var user = await _userManager.FindByEmailAsync(forgotPasswordModel.Email);
        if (user is null)
        {
            ModelState.AddModelError("Email", "User not found");
            return View();
        }

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        var link = Url.Action(nameof(ConfirmEmail), "SiginUp", new { token, email = user.Email }, Request.Scheme, Request.Host.ToString());

        string subject = "Verfiy password reset email";

        string html = string.Empty;
        using (StreamReader reader = new StreamReader("wwwroot/templates/htmlpage.html"))
        {
            html = reader.ReadToEnd();
        }


        html = html.Replace("{{link}}", link);
        html = html.Replace("{{Account}}", "Hello");

        _emailService.Send(user.Email, subject, html);

        return RedirectToAction(nameof(ForgotPasswordConfirm));
    }

    public IActionResult ResetPassword(string token, string email)
    {
        var model = new ResetPasswordVM
        {
            Email = email,
            Token = token
        };
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ResetPassword(ResetPasswordVM resetPasswordModel)
    {
        if (!ModelState.IsValid) return View(resetPasswordModel);

        AppUser user = await _userManager.FindByEmailAsync(resetPasswordModel.Email);
        if (user == null)
        {
            return View(resetPasswordModel);
        }

        var result = await _userManager.ResetPasswordAsync(user, resetPasswordModel.Token, resetPasswordModel.Password);
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View();
        }
        return RedirectToAction(nameof(ResetPasswordConfirm));
    }
}






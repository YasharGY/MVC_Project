using Edu.Core.Entities;
using EduApp.Areas.EduAdmin.Data.Service;
using EduApp.Helpers;
using GoogleAuthentication.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.Security.Claims;

namespace EduApp.Controllers;

public class LoginController : Controller
{
	private readonly UserManager<AppUser> _userManager;
	private readonly SignInManager<AppUser> _signInManager;
	public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
	{
		_userManager = userManager;
		_signInManager = signInManager;
		
	}
	public IActionResult Index()
    {
        return View();
    }

	public async Task<IActionResult> GoogleLoginCallBack(string code)
	{
		var clientId = "106159346041-jbfh25he9m5oafh0hrle91b091lecc2u.apps.googleusercontent.com";
		var url = "https://localhost:7118/Login/GoogleLoginCallBack";
		var clientSecret = "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";
		var token = await GoogleAuth.GetAuthAccessToken(code, clientId, clientSecret, url);
		var userProfile = await GoogleAuth.GetProfileResponseAsync(token.AccessToken.ToString());
		var googleUser = JsonConvert.DeserializeObject<GoogleUser>(userProfile);


		string gmailName = googleUser.Name;

		ViewBag.GmailName = gmailName;

		var existingUser = await _userManager.FindByEmailAsync(googleUser.Email);

		if (existingUser == null)
		{
		
			var appUser = new AppUser 
			{
				UserName = googleUser.Email, 
				Email = googleUser.Email,
				
			};

			var result = await _userManager.CreateAsync(appUser);
			if (result.Succeeded)
			{
				
				await _userManager.AddLoginAsync(appUser, new UserLoginInfo("Google", googleUser.Id, "Google"));

				var principal = await _signInManager.CreateUserPrincipalAsync(appUser);

				await HttpContext.SignInAsync(IdentityConstants.ExternalScheme, principal);

				
				return RedirectToAction("Index", "Home");
			}
			else
			{
				BadRequest();
			}
		}
		else
		{
			
			await _signInManager.SignInAsync(existingUser, isPersistent: false); 

			return RedirectToAction("Index", "Home");
		}

		
		return RedirectToAction("Error", "Home");
	}

}

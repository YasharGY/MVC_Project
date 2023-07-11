using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduApp.Areas.EduAdmin.Controllers;

[Area("EduAdmin")]
[Authorize]
public class DashboardController : Controller
{
	public IActionResult Index()
	{
		return View();
	}
}

using Microsoft.AspNetCore.Mvc;

namespace EduApp.Areas.EduAdmin.Controllers;

[Area("EduAdmin")]
public class DashboardController : Controller
{
	public IActionResult Index()
	{
		return View();
	}
}

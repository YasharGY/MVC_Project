using Microsoft.AspNetCore.Mvc;

namespace EduApp.Areas.EduAdmin.Controllers;

[Area("EduAdmin")]

public class NoticesController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

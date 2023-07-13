using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduApp.Controllers;
[Authorize(Roles ="Member, Admin")]
public class InvoiceController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

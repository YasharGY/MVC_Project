using Edu.DataAccess.Contexts;
using EduApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GoogleAuthentication.Services;

namespace EduApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

		public HomeController(AppDbContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> Index()
        {
            var clientId = "106159346041-jbfh25he9m5oafh0hrle91b091lecc2u.apps.googleusercontent.com";
            var url = "https://localhost:7118/Auth/GoogleLoginCallBack";
            var response = GoogleAuth.GetAuthUrl(clientId, url);
            ViewBag.response = response;


            HomeVM homeVM = new()
            {
                Sliders = await _context.Sliders.ToListAsync(),
                Notices = await _context.Notices.ToListAsync(),
                Rights = await _context.Rights.ToListAsync(),
                Courses = await _context.Courses.ToListAsync(),
                LeftEvents = await _context.LEvents.ToListAsync(),
                RightEvents = await _context.REvents.ToListAsync(),
                Testimonials = await _context.Testimonials.ToListAsync(),
                Blogs = await _context.Blogs.ToListAsync(),
            };
            return View(homeVM);
        }
    }
}

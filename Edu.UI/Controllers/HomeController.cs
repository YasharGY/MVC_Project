using Edu.DataAccess.Contexts;
using EduApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

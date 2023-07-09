using Edu.DataAccess.Contexts;
using EduApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduApp.Controllers;

public class CourseController : Controller
{
	private readonly AppDbContext _context;

	public CourseController(AppDbContext context)
	{
		_context = context;
	}

	public async Task<IActionResult> Index()
	{
		HomeVM model = new HomeVM()
		{
			Courses = await _context.Courses.ToListAsync(),
			
		};
		return View(model);
	}
}

using Edu.DataAccess.Contexts;
using EduApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduApp.Controllers;

public class BlogController : Controller
{
	private readonly AppDbContext _context;

	public BlogController(AppDbContext context)
	{
		_context = context;
	}

	public async Task<IActionResult> Index()
	{
		HomeVM homeVM = new HomeVM()
		{
			Blogs = await _context.Blogs.ToListAsync()
		};
		return View(homeVM);
	}
}

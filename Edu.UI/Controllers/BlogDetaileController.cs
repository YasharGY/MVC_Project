using Edu.DataAccess.Contexts;
using EduApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduApp.Controllers;

public class BlogDetaileController : Controller
{
	private readonly AppDbContext _context;
	public BlogDetaileController(AppDbContext context)
	{
		_context = context;
	}
	public async Task<IActionResult> Index(int id)
	{
		if (id == 0)
		{
			return NotFound();
		}
		var blog = await _context.Blogs.FindAsync(id);
		if (blog == null)
		{
			return NotFound();
		}
		ViewBag.BlogId = blog.Id;

		HomeVM homeVM = new()
		{
			Blogs = await _context.Blogs.ToListAsync(),
			Categories = await _context.Categories.ToListAsync(),
		};
		return View(homeVM);
	}
}

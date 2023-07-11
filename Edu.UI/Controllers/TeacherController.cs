using Edu.Core.Entities;
using Edu.DataAccess.Contexts;
using EduApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduApp.Controllers;

public class TeacherController : Controller
{
	public class TeachersController : Controller
	{
		private readonly AppDbContext _context;
		public TeachersController(AppDbContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> Index()
		{
			HomeVM model = new HomeVM
			{
				Teachers = await _context.teachers.ToListAsync()
			};
			return View(model);
		}
	}
}

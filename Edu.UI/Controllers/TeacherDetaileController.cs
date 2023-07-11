using Edu.DataAccess.Contexts;
using EduApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduApp.Controllers;

public class TeacherDetaileController : Controller
{
	private readonly AppDbContext _context;
	public TeacherDetaileController(AppDbContext context)
	{
		_context = context;
	}

	public async Task<IActionResult> Index(int id)
	{
		if (id == 0) BadRequest();
		var teacher = await _context.teachers.FindAsync(id);
		if (teacher is null) return NotFound();
		ViewBag.TeacherId = teacher.Id;
		

		HomeVM model = new HomeVM
		{
			Teachers = await _context.teachers.Include(td => td.teacherDetaile).ToListAsync(),
		};
		return View(model);
	}
}

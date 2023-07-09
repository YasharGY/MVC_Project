using Edu.DataAccess.Contexts;
using EduApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduApp.Controllers;

public class CourseDetaileController : Controller
{
    private readonly AppDbContext _context;

    public CourseDetaileController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(int id)
    {
        if (id == 0)
        {
            return NotFound();
        }
        var cart = _context.Courses.Find(id);
        if (cart == null)
        {
            return NotFound();
        }
        ViewBag.Id = cart.Id;

        HomeVM homeVM = new()
        {
           
            Courses = await _context.Courses.Include(c => c.CoursesDetails).ToListAsync(),
            Categories = await _context.Categories.ToListAsync()
        };
        return View(homeVM);
    }
}

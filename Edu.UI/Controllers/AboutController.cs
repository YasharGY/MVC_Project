using Edu.Core.Entities;
using Edu.DataAccess.Contexts;
using EduApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduApp.Controllers;

public class AboutController : Controller
{
    private readonly AppDbContext _context;
    public AboutController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        HomeVM model = new HomeVM
        {
            Abouts = await _context.Abouts.ToListAsync(),
            Teachers = await _context.teachers.ToListAsync(),
            Notices = await _context.Notices.ToListAsync()
        };
        return View(model);
    }
}

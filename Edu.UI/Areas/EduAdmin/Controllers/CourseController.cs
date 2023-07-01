using AutoMapper;
using Edu.Core.Entities;
using Edu.DataAccess.Contexts;
using EduApp.Areas.EduAdmin.ViewModels.CourseViewModel;
using EduApp.Areas.EduAdmin.ViewModels.NoticeViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduApp.Areas.EduAdmin.Controllers;
[Area("EduAdmin")]

    public class CourseController : Controller
    {
	private readonly AppDbContext _context;
	private readonly IMapper _mapper;
	public CourseController(AppDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}
	public async Task<IActionResult> Index()
	{
		return View(await _context.Courses.ToArrayAsync());
	}

	public IActionResult Create()
	{
		return View();
	}
    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> Create(CoursePostVM coursePost)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        CoursesOffer courses = _mapper.Map<CoursesOffer>(coursePost);
        await _context.Courses.AddAsync(courses);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}

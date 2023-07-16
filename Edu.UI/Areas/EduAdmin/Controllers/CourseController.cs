using AutoMapper;
using Edu.Core.Entities;
using Edu.DataAccess.Contexts;
using EduApp.Areas.EduAdmin.ViewModels.CourseViewModel;
using EduApp.Areas.EduAdmin.ViewModels.NoticeViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

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
    public async Task<IActionResult> Delete(int id)
    {
        CoursesOffer coursedb = await _context.Courses.FindAsync(id);
        if (coursedb == null)
        {
            return NotFound();

        }
        return View(coursedb);
    }
    [HttpPost]
    [ActionName("Delete")]
    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> DeletePost(int id)
    {
        CoursesOffer coursedb = await _context.Courses.FindAsync(id);
        if (coursedb == null)
        {
            return NotFound();

        }
        _context.Courses.Remove(coursedb);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Update(int id)
    {
        CoursesOffer coursedb = await _context.Courses.FindAsync(id);
        if (coursedb == null)
        {
            return NotFound();

        }
        return View(coursedb);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(int id, CoursesOffer course)
    {
        if (id != course.Id)
        {
            return BadRequest();
        }
        if (!ModelState.IsValid)
        {
            return View(course);
        }
        CoursesOffer coursedb = await _context.Courses.AsNoTracking().FirstOrDefaultAsync(s => s.Id == course.Id);
        if (coursedb == null)
        {
            return NotFound();
        }
        _context.Entry(course).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

}
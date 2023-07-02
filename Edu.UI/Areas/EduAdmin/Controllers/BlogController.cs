using AutoMapper;
using Edu.Core.Entities;
using Edu.DataAccess.Contexts;
using EduApp.Areas.EduAdmin.ViewModels.BlogViewModel;
using EduApp.Areas.EduAdmin.ViewModels.CourseViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduApp.Areas.EduAdmin.Controllers;
[Area("EduAdmin")]

public class BlogController : Controller
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    public BlogController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<IActionResult> Index()
    {
        return View(await _context.Blogs.ToArrayAsync());
    }
	public IActionResult Create()
	{
		return View();
	}
	[HttpPost]
	[AutoValidateAntiforgeryToken]
	public async Task<IActionResult> Create(BlogPostVM blogPost)
	{
		if (!ModelState.IsValid)
		{
			return View();
		}
		Blog blogs = _mapper.Map<Blog>(blogPost);
		await _context.Blogs.AddAsync(blogs);
		await _context.SaveChangesAsync();

		return RedirectToAction(nameof(Index));
	}
	public async Task<IActionResult> Delete(int id)
	{
		Blog blogdb = await _context.Blogs.FindAsync(id);
		if (blogdb == null)
		{
			return NotFound();

		}
		return View(blogdb);
	}
	[HttpPost]
	[ActionName("Delete")]
	[AutoValidateAntiforgeryToken]
	public async Task<IActionResult> DeletePost(int id)
	{
		Blog blogdb = await _context.Blogs.FindAsync(id);
		if (blogdb == null)
		{
			return NotFound();

		}
		_context.Blogs.Remove(blogdb);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
    public async Task<IActionResult> Update(int id)
    {
        Blog blogdb = await _context.Blogs.FindAsync(id);
        if (blogdb == null)
        {
            return NotFound();

        }
        return View(blogdb);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(int id, Blog blog)
    {
        if (id != blog.Id)
        {
            return BadRequest();
        }
        if (!ModelState.IsValid)
        {
            return View(blog);
        }
        CoursesOffer coursedb = await _context.Courses.AsNoTracking().FirstOrDefaultAsync(s => s.Id == blog.Id);
        if (coursedb == null)
        {
            return NotFound();
        }
        _context.Entry(blog).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}

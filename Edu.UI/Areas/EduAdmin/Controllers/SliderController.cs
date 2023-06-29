using Edu.Core.Entities;
using Edu.DataAccess.Contexts;
using EduApp.Areas.EduAdmin.ViewModels.SliderViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduApp.Areas.EduAdmin.Controllers;
[Area("EduAdmin")]

public class SliderController : Controller
{
	private readonly AppDbContext _context;

	public SliderController(AppDbContext context)
	{
		_context = context;
	}

	public async Task<IActionResult> Index()
	{
		return View(await _context.Sliders.ToArrayAsync());
	}

	public IActionResult Create()
	{
		return View();
	}

	[HttpPost]

    public async Task<IActionResult> Create(SliderPostVM sliderpost)
    {
		if (!ModelState.IsValid)
		{
			return View();
		}
		Slider slider = new()
		{
			Title = sliderpost.Title,
			Title2 = sliderpost.Title2,
			Description = sliderpost.Description,
			ImagePath = sliderpost.ImagePath

		};
		await _context.Sliders.AddAsync(slider);
		await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

	


	public async Task<IActionResult> Delete(int id)
	{
		Slider sliderdb = await _context.Sliders.FindAsync(id);
		if (sliderdb == null) 
		{
			return NotFound();
		
		}
		return View(sliderdb);
	}

}

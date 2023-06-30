using AutoMapper;
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
	private readonly IMapper _mapper;

	public SliderController(AppDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
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
    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> Create(SliderPostVM sliderpost)
    {
		if (!ModelState.IsValid)
		{
			return View();
		}
		Slider slider = _mapper.Map<Slider>(sliderpost);
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

	[HttpPost]
	[ActionName("Delete")]
	[AutoValidateAntiforgeryToken]
    public async Task<IActionResult> DeletePost(int id)
    {
        Slider sliderdb = await _context.Sliders.FindAsync(id);
        if (sliderdb == null)
        {
            return NotFound();

        }
		_context.Sliders.Remove(sliderdb);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(int id)
    {
        Slider sliderdb = await _context.Sliders.FindAsync(id);
        if (sliderdb == null)
        {
            return NotFound();

        }
		return View(sliderdb);
    }
	[HttpPost]
	[ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(int id,Slider slider)
    {
		if (id != slider.Id)
		{
			return BadRequest();
		}
		if (!ModelState.IsValid)
		{
			return View(slider);
		}
		Slider sliderDb = await _context.Sliders.AsNoTracking().FirstOrDefaultAsync(s =>s.Id==slider.Id);
		if (sliderDb == null)
		{
			return NotFound();
		}
		_context.Entry(slider).State = EntityState.Modified;
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));	
    }

}

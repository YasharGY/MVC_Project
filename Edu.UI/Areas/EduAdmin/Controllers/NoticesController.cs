using AutoMapper;
using Edu.Core.Entities;
using Edu.DataAccess.Contexts;
using EduApp.Areas.EduAdmin.ViewModels.NoticeViewModel;
using EduApp.Areas.EduAdmin.ViewModels.SliderViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduApp.Areas.EduAdmin.Controllers;

[Area("EduAdmin")]

public class NoticesController : Controller
{
    private readonly AppDbContext _context;
	private readonly IMapper _mapper;
	public NoticesController(AppDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}
	public async Task<IActionResult> Index()
	{
		return View(await _context.Notices.ToArrayAsync());
	}

	public IActionResult Create()
	{
		return View();
	}

	[HttpPost]
	[AutoValidateAntiforgeryToken]
	public async Task<IActionResult> Create(NoticePostVM noticepost)
	{
		if (!ModelState.IsValid)
		{
			return View();
		}
		NoticeBoard notices = _mapper.Map<NoticeBoard>(noticepost);
		await _context.Notices.AddAsync(notices);
		await _context.SaveChangesAsync();

		return RedirectToAction(nameof(Index));
	}
}

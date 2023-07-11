using Edu.DataAccess.Contexts;
using EduApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduApp.Controllers;

public class EventDetaileController : Controller
{
    private readonly AppDbContext _context;
    public EventDetaileController(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index(int id)
    {
        if (id == 0)
        {
            return NotFound();
        }
        var Event = _context.LEvents.Find(id);
        if (Event == null)
        {
            return BadRequest();
        }
        ViewBag.EventProductId = Event.Id;

        var eventsDetails = await _context.EventDetailes
       .Include(ed => ed.Events)
       .ToListAsync();

        var eventsIds = eventsDetails.Select(ed => ed.Events.Id).ToList();
        var events = await _context.LEvents
            .Where(e => eventsIds.Contains(e.Id))
            .Include(e => e.EventSpeakers)
                .ThenInclude(es => es.Speakers)
            .ToListAsync();


        return View(new HomeVM
        {

            EventDetailes = eventsDetails,
            LeftEvents = events,
			Blogs = await _context.Blogs.ToListAsync(),

		});
    }
}

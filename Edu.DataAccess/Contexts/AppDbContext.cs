

using Edu.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Edu.DataAccess.Contexts;

public class AppDbContext:IdentityDbContext<AppUser> 
{
	public AppDbContext(DbContextOptions<AppDbContext> options):base(options){}

	public DbSet<Slider> Sliders { get; set; } = null!;
	public DbSet<NoticeBoard> Notices { get; set; } 
	public DbSet<RightBoard> Rights { get; set; } 
	public DbSet<CoursesOffer> Courses { get; set; } 
	public DbSet<LeftEvent> LEvents { get; set; }
	public DbSet<RightEvent> REvents { get; set; }
	public DbSet<Testimonial> Testimonials { get; set; }
	public DbSet<Blog> Blogs { get; set; }
	public DbSet<CourseDetaile> CourseDetailes { get; set; }
	public DbSet<Categorie> Categories { get; set; }
	public DbSet<EventDetaile> EventDetailes { get; set; }
	public DbSet<Speaker> Speakers { get; set; }
	public DbSet<EventSpeaker> EventSpeakers { get; set; }
	public DbSet<Teacher> teachers { get; set; }
	public DbSet<TeacherDetaile> teacherDetailes { get; set; }
	public DbSet<About> Abouts { get; set; }

}

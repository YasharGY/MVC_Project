

using Edu.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Edu.DataAccess.Contexts;

public class AppDbContext:DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options):base(options){}

	public DbSet<Slider> Sliders { get; set; } = null!;
	public DbSet<NoticeBoard> Notices { get; set; } 
	public DbSet<RightBoard> Rights { get; set; } 
}

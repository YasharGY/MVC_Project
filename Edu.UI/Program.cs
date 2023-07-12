using Edu.Core.Entities;
using Edu.DataAccess.Contexts;
using EduApp.Areas.EduAdmin.Data.Service;
using EduApp.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<AppDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));

});
builder.Services.Configure<EmailSetting>(builder.Configuration.GetSection("EmailSetting"));
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<EmailSetting>();

builder.Services.AddIdentity<AppUser, IdentityRole>(IdentityOptions =>
{
	IdentityOptions.User.RequireUniqueEmail = true;
	IdentityOptions.Password.RequireNonAlphanumeric = true;
	IdentityOptions.Password.RequiredLength = 8;
	IdentityOptions.Password.RequireDigit = true;
	IdentityOptions.Password.RequireLowercase = true;
	IdentityOptions.Password.RequireUppercase = true;

	IdentityOptions.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
	IdentityOptions.Lockout.MaxFailedAccessAttempts = 3;
	IdentityOptions.Lockout.AllowedForNewUsers = true;
}).AddEntityFrameworkStores<AppDbContext>()
	.AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(options =>
{
	options.LoginPath = "/EduAdmin/Auth/Login";
});

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.MapControllerRoute(
name: "areas",
pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"

	);


app.MapControllerRoute(
	name: "Default",
	pattern: "{controller=Home}/{action=Index}/{id?}"

	);

app.Run();




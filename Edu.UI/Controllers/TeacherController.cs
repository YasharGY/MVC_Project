﻿using Edu.Core.Entities;
using Edu.DataAccess.Contexts;
using EduApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduApp.Controllers;

	public class TeacherController : Controller
	{
		private readonly AppDbContext _context;
		public TeacherController(AppDbContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> Index()
		{
			HomeVM model = new HomeVM
			{
				Teachers = await _context.teachers.ToListAsync()
			};
			return View(model);
		}
	}


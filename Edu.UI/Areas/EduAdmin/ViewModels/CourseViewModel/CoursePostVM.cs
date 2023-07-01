using System.ComponentModel.DataAnnotations;

namespace EduApp.Areas.EduAdmin.ViewModels.CourseViewModel
{
	public class CoursePostVM
	{
		public string ImagePath { get; set; }
		[Required, MaxLength(30)]
		public string Title { get; set; }
		[Required, MaxLength(150)]
		public string Description { get; set; }

	}
}

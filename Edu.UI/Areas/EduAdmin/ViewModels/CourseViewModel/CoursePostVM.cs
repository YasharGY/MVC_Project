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
		public string AboutCourse { get; set; } = null!;
		[Required, MaxLength(350)]
		public string AboutCourseDescription { get; set; } = null!;
		[Required, MaxLength(50)]
		public string ToApply { get; set; } = null!;
		[Required, MaxLength(350)]
		public string ToApplyDescription { get; set; } = null!;
		[Required, MaxLength(50)]
		public string Certification { get; set; } = null!;
		[Required, MaxLength(400)]
		public string CertificationDescription { get; set; } = null!;
		public DateTime Starts { get; set; }
		[Required]
		public int Month { get; set; }
		[Required]
		public int Hours { get; set; }
		[Required, MaxLength(25)]
		public string Level { get; set; } = null!;
		[Required, MaxLength(22)]
		public string Language { get; set; } = null!;
		[Required]
		public int Students { get; set; }
		[Required, MaxLength(20)]
		public string Assesments { get; set; } = null!;
		[Required]
		public int CourseFee { get; set; }

		public int CategoryId { get; set; }
	}
}

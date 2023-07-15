using System.ComponentModel.DataAnnotations;

namespace EduApp.Areas.EduAdmin.ViewModels.CourseDetaileViewModel;

public class CourseDetailePostVM
{
	public string ImagePath { get; set; } = null!;
	public string Course { get; set; } = null!;
	public string Description { get; set; } = null!;
	[Required, MaxLength(50)]
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

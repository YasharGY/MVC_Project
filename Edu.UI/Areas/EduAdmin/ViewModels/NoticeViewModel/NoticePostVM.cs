using System.ComponentModel.DataAnnotations;

namespace EduApp.Areas.EduAdmin.ViewModels.NoticeViewModel
{
	public class NoticePostVM
	{
		public string? Title { get; set; }
		[Required, MaxLength(20)]
		public string Date { get; set; } = null!;
		[Required, MaxLength(200)]
		public string Description { get; set; } = null!;
	}
}

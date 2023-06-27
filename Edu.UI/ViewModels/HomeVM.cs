using Edu.Core.Entities;

namespace EduApp.ViewModels;

public class HomeVM
{
	public IEnumerable<Slider> Sliders { get; set; }
	public IEnumerable<NoticeBoard> Notices { get; set; }
	public IEnumerable<RightBoard> Rights { get; set; }

}

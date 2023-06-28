using Edu.Core.Entities;

namespace EduApp.ViewModels;

public class HomeVM
{
	public IEnumerable<Slider> Sliders { get; set; }
	public IEnumerable<NoticeBoard> Notices { get; set; }
	public IEnumerable<RightBoard> Rights { get; set; }
	public IEnumerable<CoursesOffer> Courses { get; set;}
	public IEnumerable<LeftEvent> LeftEvents { get; set; }
	public IEnumerable<RightEvent> RightEvents { get; set; }
	public IEnumerable<Testimonial> Testimonials { get; set; }

}

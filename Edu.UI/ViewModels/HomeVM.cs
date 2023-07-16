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
	public IEnumerable<Blog> Blogs { get; set; }
	public IEnumerable<Categorie> Categories { get; set; }
	public IEnumerable<CourseDetaile> CourseDetailes { get; set; }
	public IEnumerable<EventDetaile> EventDetailes { get; set; }
	public IEnumerable<Speaker> Speakers { get; set; }
	public IEnumerable<EventSpeaker> EventSpeakers { get; set; }
	public IEnumerable<Teacher> Teachers { get; set; }
	public IEnumerable<TeacherDetaile> TeacherDetailes { get; set; }
	public IEnumerable<About> Abouts { get; set; }


}

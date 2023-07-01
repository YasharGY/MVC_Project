using AutoMapper;
using Edu.Core.Entities;
using EduApp.Areas.EduAdmin.ViewModels.CourseViewModel;


namespace EduApp.Mappers
{
	public class CourseProfile : Profile
	{
		public CourseProfile()
		{
			CreateMap<CoursePostVM, CoursesOffer>().ReverseMap();
		}
	}
}
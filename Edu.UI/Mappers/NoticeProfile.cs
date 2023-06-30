using AutoMapper;
using Edu.Core.Entities;
using EduApp.Areas.EduAdmin.ViewModels.NoticeViewModel;
using EduApp.Areas.EduAdmin.ViewModels.SliderViewModel;

namespace EduApp.Mappers
{
	public class NoticeProfile : Profile
	{
		public NoticeProfile()
		{
			CreateMap<NoticePostVM, NoticeBoard>().ReverseMap();
		}
	}
}

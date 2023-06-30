using AutoMapper;
using Edu.Core.Entities;
using EduApp.Areas.EduAdmin.ViewModels.SliderViewModel;

namespace EduApp.Mappers;

public class SliderProfile: Profile
{
	public SliderProfile()
	{
		CreateMap<SliderPostVM,Slider>().ReverseMap();
	}
}

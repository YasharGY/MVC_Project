using AutoMapper;
using Edu.Core.Entities;
using EduApp.Areas.EduAdmin.ViewModels.BlogViewModel;
using EduApp.Areas.EduAdmin.ViewModels.CourseViewModel;

namespace EduApp.Mappers;

public class BlogProfile:Profile
{
    public BlogProfile()
    {
        CreateMap<BlogPostVM, Blog>().ReverseMap();
    }
}

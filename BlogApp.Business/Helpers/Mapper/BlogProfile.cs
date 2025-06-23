using AutoMapper;
using BlogApp.Business.DTOs.Blog;
using BlogApp.Core.Entities;

namespace BlogApp.Business.Helpers.Mapper;

public class BlogProfile: Profile
{
    public BlogProfile()
    {
        CreateMap<GetBlogDto, Blog>().ReverseMap();
        CreateMap<AuthorGetDto, AppUser>().ReverseMap();
    }
}
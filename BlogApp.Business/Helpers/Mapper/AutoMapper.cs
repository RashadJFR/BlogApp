using AutoMapper;
using BlogApp.Business.DTOs.Category;
using BlogApp.Core.Entities;

namespace BlogApp.Business.Helpers.Mapper;

public class AutoMapper:Profile
{
    public AutoMapper()
    {
        CreateMap<GetCategoryDto, Category>().ReverseMap();
    }
}
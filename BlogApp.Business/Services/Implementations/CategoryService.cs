using AutoMapper;
using BlogApp.Business.DTOs.Category;
using BlogApp.Business.Exceptions.CategoryExceptions;
using BlogApp.Business.Exceptions.Common;
using BlogApp.Business.Services.Interfaces;
using BlogApp.DAL.Repositories.Interfaces;

namespace BlogApp.Business.Services.Implementations;

public class CategoryService: ICategoryService
{
    readonly ICategoryRepository _rep;
    readonly IMapper _mapper;

    public CategoryService(ICategoryRepository rep, IMapper mapper)
    {
        _rep = rep;
        _mapper = mapper;
    }

    public GetCategoryDto GetById(int id)
    {
        if (id <= 0)
        {
            throw new NegativeIdException();
        }
        
        GetCategoryDto dto = _mapper.Map<GetCategoryDto>(_rep.GetById(id));
        return dto != null ? dto : throw new CategoryNullException();
    }
}
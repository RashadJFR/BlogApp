using AutoMapper;
using BlogApp.Business.DTOs.Category;
using BlogApp.Business.Exceptions.CategoryExceptions;
using BlogApp.Business.Exceptions.Common;
using BlogApp.Business.Services.Interfaces;
using BlogApp.Core.Entities;
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

    public async Task<GetCategoryDto> CreateAsync(CreateCategoryDto dto)
    {
        if (await _rep.IsExist(c => c.Name == dto.Name))
        {
            throw new CategoryNameExistException();
        }
        
        var category = _mapper.Map<Category>(dto);
        var newCategory = await _rep.Create(category);
        await _rep.SaveChangesAsync();
        return _mapper.Map<GetCategoryDto>(newCategory);
    }

    public async Task UpdateAsync(UpdateCategoryDto dto)
    {
        var oldCategory = await GetById(dto.Id);
        if (await _rep.IsExist(c => c.Name == dto.Name))
        {
            throw new CategoryNameExistException();
        }
        
        oldCategory = _mapper.Map<GetCategoryDto>(dto);
        
        _rep.Update(_mapper.Map<Category>(oldCategory));
        await _rep.SaveChangesAsync();
    }

    public async Task<GetCategoryDto> GetById(int id)
    {
        if (id <= 0)
        {
            throw new NegativeIdException();
        }
        
        GetCategoryDto dto = _mapper.Map<GetCategoryDto>( await _rep.GetById(id));
        return dto != null ? dto : throw new CategoryNullException();
    }

    public List<GetCategoryDto> GetAll()
    {
        List<GetCategoryDto> dtos = new List<GetCategoryDto>();
        var datas = _rep.GetAll();

        foreach (var data in datas)
        {
            GetCategoryDto dto = _mapper.Map<GetCategoryDto>(data);
            dtos.Add(dto);
        }

        return dtos;
    }

    public async Task DeleteAsync(int id)
    {
        var category = await GetById(id);
        _rep.Delete(_mapper.Map<Category>(category));
        await _rep.SaveChangesAsync();
    }

    public async Task SoftDeleteAsync(int id)
    {
        var category = await GetById(id);
        _rep.SoftDelete(_mapper.Map<Category>(category));
        await _rep.SaveChangesAsync();
    }
}
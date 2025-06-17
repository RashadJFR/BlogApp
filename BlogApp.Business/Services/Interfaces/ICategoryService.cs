using BlogApp.Business.DTOs.Category;

namespace BlogApp.Business.Services.Interfaces;

public interface ICategoryService
{
    Task<GetCategoryDto> CreateAsync(CreateCategoryDto dto);
    Task UpdateAsync(UpdateCategoryDto dto);
    Task<GetCategoryDto> GetById(int id);
    List<GetCategoryDto> GetAll();
    Task DeleteAsync(int id);
    Task SoftDeleteAsync(int id);
}
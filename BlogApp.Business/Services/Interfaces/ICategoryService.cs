using BlogApp.Business.DTOs.Category;

namespace BlogApp.Business.Services.Interfaces;

public interface ICategoryService
{
    GetCategoryDto GetById(int id);
}
using BlogApp.Business.DTOs.Blog;

namespace BlogApp.Business.Services.Interfaces;

public interface IBlogService
{
    public List<GetBlogDto> GetAll();
}
using AutoMapper;
using BlogApp.Business.DTOs.Blog;
using BlogApp.Business.Services.Interfaces;
using BlogApp.DAL.Repositories.Interfaces;

namespace BlogApp.Business.Services.Implementations;

public class BlogService:IBlogService
{
    readonly IBlogRepository _blogRepository;
    readonly IMapper _mapper;

    public BlogService(IBlogRepository blogRepository, IMapper mapper)
    {
        _blogRepository = blogRepository;
        _mapper = mapper;
    }

    public List<GetBlogDto> GetAll()
    {
        var blogs = _blogRepository.GetAll(null, "Author", "BlogsCategories", "BlogsCategories.Category");
        var returnBlogs = _mapper.Map<List<GetBlogDto>>(blogs);
        
        return returnBlogs;
    }
}
using BlogApp.Core.Entities;
using BlogApp.DAL.Context;
using BlogApp.DAL.Repositories.Interfaces;

namespace BlogApp.DAL.Repositories.Implementations;

public class BlogRepository: Repository<Blog>, IBlogRepository
{
    public BlogRepository(BlogAppDbContext context) : base(context){}
}
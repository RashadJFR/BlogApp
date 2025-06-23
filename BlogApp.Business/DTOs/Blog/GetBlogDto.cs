namespace BlogApp.Business.DTOs.Blog;
using Core.Entities;

public record GetBlogDto
{
    public string Title { get; init; }
    public string Description { get; init; }
    public string AuthorId { get; init; }
    public AuthorGetDto Author { get; init; }
    public ICollection<BlogsCategories> BlogsCategories { get; init; }
}
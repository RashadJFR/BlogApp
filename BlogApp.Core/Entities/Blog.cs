using BlogApp.Core.Entities.Common;

namespace BlogApp.Core.Entities;

public class Blog:BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int ViewerCount { get; set; }
    public string AuthorId { get; set; }
    public AppUser Author { get; set; }
    public ICollection<BlogsCategories> BlogsCategories { get; set; }
}
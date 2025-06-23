using System.Text.Json.Serialization;
using BlogApp.Core.Entities.Common;

namespace BlogApp.Core.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; }
    [JsonIgnore]
    public ICollection<BlogsCategories> BlogsCategories { get; set; }
    
}
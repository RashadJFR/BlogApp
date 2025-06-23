using System.Text.Json.Serialization;
using BlogApp.Core.Entities.Common;
using Microsoft.AspNetCore.Identity;

namespace BlogApp.Core.Entities;

public class AppUser:IdentityUser
{
    public string Name { get; set; }
    public string Surname { get; set; }
    [JsonIgnore]
    public ICollection<Blog> Blogs { get; set; }
}
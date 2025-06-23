using System.Reflection;
using BlogApp.Core.Entities;
using BlogApp.Core.Entities.Common;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.DAL.Context;

public class BlogAppDbContext : IdentityDbContext<AppUser>
{
    public BlogAppDbContext(DbContextOptions<BlogAppDbContext> options):base(options) { }
    
    public DbSet<Category> Categories { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<BlogsCategories> BlogsCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
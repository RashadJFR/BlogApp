using BlogApp.Core.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.DAL.Repositories.Interfaces;

public interface IRepository<TEntity> where TEntity : BaseEntity, new()
{
    public DbSet<TEntity> Table { get; }
    public TEntity GetById(int id);
    public IQueryable<TEntity> GetAll();
}
using System.Linq.Expressions;
using BlogApp.Core.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.DAL.Repositories.Interfaces;

public interface IRepository<TEntity> where TEntity : BaseEntity, new()
{
    public DbSet<TEntity> Table { get; }
    public Task<TEntity?> GetById(int id);
    public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>>? expression = null, params string[]? includes);
    
    public Task<TEntity> Create(TEntity entity);
    public void Update(TEntity entity);
    public void Delete(TEntity entity);
    public void SoftDelete(TEntity entity);
    public Task<int> SaveChangesAsync();
    public Task<bool> IsExist(Expression<Func<TEntity, bool>> expression);
}
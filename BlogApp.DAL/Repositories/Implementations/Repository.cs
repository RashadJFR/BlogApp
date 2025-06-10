using BlogApp.Core.Entities.Common;
using BlogApp.DAL.Context;
using BlogApp.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.DAL.Repositories.Implementations;

public class Repository<TEntity>:IRepository<TEntity> where TEntity: BaseEntity, new()
{
    private readonly BlogAppDbContext _context;

    public Repository(BlogAppDbContext context)
    {
        _context = context;
    }

    public DbSet<TEntity> Table => _context.Set<TEntity>();
    
    public TEntity GetById(int id)
    {
        return Table.FirstOrDefault(x => x.Id == id);
    }

    public IQueryable<TEntity> GetAll()
    {
        return Table;
    }
}
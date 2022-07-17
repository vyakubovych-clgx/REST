using Microsoft.EntityFrameworkCore;
using REST.DataAccess.Entities;
using REST.DataAccess.Interfaces;

namespace REST.DataAccess.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected DbContext DbContext;
    protected DbSet<TEntity> DbSet;
    protected BaseRepository(DbContext dbContext)
    {
        DbContext = dbContext;
        DbSet = dbContext.Set<TEntity>();
    }

    public IQueryable<TEntity> GetAll() => DbSet;

    public async Task<TEntity> GetByIdAsync(int id) => await DbSet.FindAsync(id).ConfigureAwait(false);

    public async Task AddAsync(TEntity entity)
    {
        await DbSet.AddAsync(entity).ConfigureAwait(false);
    }

    public void Update(TEntity entity)
    {
        DbContext.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(TEntity entity)
    {
        DbSet.Remove(entity);
    }

    public async Task DeleteByIdAsync(int id)
    {
        var entity = await DbSet.FindAsync(id).ConfigureAwait(false);
        Delete(entity);
    }
}
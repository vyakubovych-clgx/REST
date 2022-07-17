using Microsoft.EntityFrameworkCore;
using REST.DataAccess.Context;
using REST.DataAccess.Entities;
using REST.DataAccess.Interfaces;

namespace REST.DataAccess.Repositories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(CatalogDbContext dbContext) : base(dbContext)
    {
    }

    public IQueryable<Category> GetAllWithItems() => DbSet.Include(c => c.Items);

    public async Task<Category> GetByIdWithItemsAsync(int id)
        => await DbSet.Include(c => c.Items).SingleOrDefaultAsync(c => c.Id == id).ConfigureAwait(false);
}
using REST.DataAccess.Context;
using REST.DataAccess.Interfaces;
using REST.DataAccess.Repositories;

namespace REST.DataAccess;

public class UnitOfWork : IUnitOfWork
{
    private readonly CatalogDbContext _context;

    public UnitOfWork(CatalogDbContext context)
    {
        _context = context;
        CategoryRepository = new CategoryRepository(context);
        ItemRepository = new ItemRepository(context);
    }

    public ICategoryRepository CategoryRepository { get; }
    public IItemRepository ItemRepository { get; }
    public async Task<int> SaveAsync() => await _context.SaveChangesAsync().ConfigureAwait(false);
}
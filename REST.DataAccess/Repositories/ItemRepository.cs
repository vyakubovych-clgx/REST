using Microsoft.EntityFrameworkCore;
using REST.DataAccess.Context;
using REST.DataAccess.Entities;
using REST.DataAccess.Interfaces;

namespace REST.DataAccess.Repositories;

public class ItemRepository : BaseRepository<Item>, IItemRepository
{
    public ItemRepository(CatalogDbContext dbContext) : base(dbContext)
    {
    }
}
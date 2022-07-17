using Microsoft.EntityFrameworkCore;
using REST.DataAccess.Entities;

namespace REST.DataAccess.Context;

public class CatalogDbContext : DbContext
{
    public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Item> Items { get; set; }
}
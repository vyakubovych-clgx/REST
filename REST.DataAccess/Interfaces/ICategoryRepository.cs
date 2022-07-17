using REST.DataAccess.Entities;

namespace REST.DataAccess.Interfaces;

public interface ICategoryRepository : IBaseRepository<Category>
{
    IQueryable<Category> GetAllWithItems();
    Task<Category> GetByIdWithItemsAsync(int id);
}
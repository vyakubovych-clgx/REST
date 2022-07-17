namespace REST.DataAccess.Interfaces;

public interface IUnitOfWork
{
    ICategoryRepository CategoryRepository { get; }
    IItemRepository ItemRepository { get; }

    Task<int> SaveAsync();
}
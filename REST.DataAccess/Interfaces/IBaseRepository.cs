using REST.DataAccess.Entities;

namespace REST.DataAccess.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetByIdAsync(int id);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task DeleteByIdAsync(int id);
}
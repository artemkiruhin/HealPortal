namespace HealPortal.Domain.Repositories.Base;

public interface ICrudRepository<TEntity>
{
    Task<TEntity?> GetByIdAsync(Guid id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<TEntity> DeleteAsync(TEntity entity); 
    Task<List<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);
}
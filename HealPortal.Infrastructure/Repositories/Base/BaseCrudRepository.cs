using HealPortal.Domain.Repositories;
using HealPortal.Domain.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace HealPortal.Infrastructure.Repositories.Base;

public class BaseCrudRepository<TEntity> : ICrudRepository<TEntity> where TEntity : class
{
    protected readonly IUnitOfWork _database;
    protected readonly DbSet<TEntity> _dbSet;
    
    public BaseCrudRepository(IUnitOfWork database, AppDbContext context)
    {
        _database = database;
        _dbSet = context.Set<TEntity>();
    }

    public async Task<TEntity?> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.AsNoTracking().ToListAsync();
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await _database.BeginTransactionAsync();
        var result = await _dbSet.AddAsync(entity);
        await _database.SaveChangesAsync();
        await _database.CommitTransactionAsync();
        return result.Entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        await _database.BeginTransactionAsync();
        var result = _dbSet.Update(entity);
        await _database.SaveChangesAsync();
        await _database.CommitTransactionAsync();
        return result.Entity;
    }

    public async Task<TEntity> DeleteAsync(TEntity entity)
    {
        await _database.BeginTransactionAsync();
        var result = _dbSet.Remove(entity);
        await _database.SaveChangesAsync();
        await _database.CommitTransactionAsync();
        return result.Entity;
    }

    public async Task<List<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await _database.BeginTransactionAsync();
        await _dbSet.AddRangeAsync(entities);
        await _database.SaveChangesAsync();
        await _database.CommitTransactionAsync();
        return entities.ToList();
    }
}
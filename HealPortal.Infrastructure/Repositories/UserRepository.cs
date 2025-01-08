using HealPortal.Domain.Models.Entities;
using HealPortal.Domain.Repositories;
using HealPortal.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace HealPortal.Infrastructure.Repositories;

public class UserRepository : BaseCrudRepository<UserEntity>, IUserRepository
{
    public UserRepository(IUnitOfWork database, AppDbContext context) : base(database, context)
    {
    }

    public async Task<UserEntity?> GetByUsernameAsync(string username)
    {
        return await _dbSet.AsNoTracking().FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task<UserEntity?> GetByUsernameAndPasswordHashAsync(string username, string passwordHash)
    {
        return await _dbSet.AsNoTracking()
            .FirstOrDefaultAsync(u => u.Username == username && u.PasswordHash == passwordHash);
    }
}
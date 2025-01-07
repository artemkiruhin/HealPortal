using HealPortal.Domain.Models.Entities;
using HealPortal.Domain.Repositories.Base;

namespace HealPortal.Domain.Repositories;

public interface IUserRepository : ICrudRepository<UserEntity>
{
    Task<UserEntity?> GetByUsernameAsync(string username);
    Task<UserEntity?> GetByUsernameAndPasswordHashAsync(string username, string passwordHash);
}
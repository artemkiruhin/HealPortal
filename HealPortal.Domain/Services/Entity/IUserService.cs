using HealPortal.Domain.Models.Dtos;
using HealPortal.Domain.Models.Entities;

namespace HealPortal.Domain.Services.Entity;

public interface IUserService
{
    Task<UserDto> GetByIdAsync(Guid id);
    Task<bool> Registration(string username, string passwordHash, UserRole role = UserRole.User);
    Task<string> Login(string username, string passwordHash);
    Task<bool> RemoveImg(Guid id);
    Task<bool> ChangePassword(Guid id, string oldPassword, string newPassword);
    Task<bool> SetImg(Guid id, string img);
}
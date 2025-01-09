using HealPortal.Domain.Models.Dtos;

namespace HealPortal.Domain.Services.Entity;

public interface ITagService
{
    Task<bool?> GetByIdAsync(Guid id);
    Task<IEnumerable<TagDto>> GetAllAsync();
    Task<bool> AddAsync(string name);
    Task<bool> UpdateAsync(string name);
    Task<bool> DeleteAsync(Guid id); 
}
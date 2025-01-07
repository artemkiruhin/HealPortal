namespace HealPortal.Domain.Services.Entity.Base;

public interface ICrudService<TDto>
{
    Task<TDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<TDto>> GetAllAsync();
    Task<bool> DeleteAsync(Guid id); 
}
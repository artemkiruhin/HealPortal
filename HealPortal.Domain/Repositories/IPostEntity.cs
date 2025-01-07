using HealPortal.Domain.Models.Entities;
using HealPortal.Domain.Repositories.Base;

namespace HealPortal.Domain.Repositories;

public interface IPostRepository : ICrudRepository<PostEntity>
{
    Task<IEnumerable<PostEntity>> GetByTitleAsync(string title);
    Task<IEnumerable<PostEntity>> GetByContentAsync(string content);
    Task<IEnumerable<PostEntity>> GetByUserIdAsync(Guid userId);
    Task<IEnumerable<PostEntity>> GetByTagsAsync(string[] tags);
    Task<IEnumerable<PostEntity>> GetByCreatedDateAsync(bool ascending = true);
    Task<IEnumerable<PostEntity>> GetByDurationAsync(uint durationInMinutes);
    Task<IEnumerable<PostEntity>> GetByWatchersAsync(uint watchers, bool ascending = false);
    Task<IEnumerable<PostEntity>> GetByLikesAsync(uint likes, bool ascending = true);
    Task<IEnumerable<PostEntity>> GetByDislikesAsync(uint dislikes, bool ascending = true);
}
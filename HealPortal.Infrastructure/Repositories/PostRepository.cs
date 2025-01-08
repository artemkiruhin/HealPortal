using HealPortal.Domain.Models.Entities;
using HealPortal.Domain.Repositories;
using HealPortal.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace HealPortal.Infrastructure.Repositories;

public class PostRepository : BaseCrudRepository<PostEntity>, IPostRepository
{
    public PostRepository(IUnitOfWork database, AppDbContext context) : base(database, context)
    {
    }

    public async Task<IEnumerable<PostEntity>> GetByTitleAsync(string title)
    {
        return await _dbSet.Where(p => p.Title.Contains(title)).ToListAsync();
    }

    public async Task<IEnumerable<PostEntity>> GetByContentAsync(string content)
    {
        return await _dbSet.Where(p => p.Content.Contains(content)).ToListAsync();
    }

    public async Task<IEnumerable<PostEntity>> GetByUserIdAsync(Guid userId)
    {
        return await _dbSet.Where(p => p.UserId == userId).ToListAsync();
    }

    public async Task<IEnumerable<PostEntity>> GetByTagsAsync(string[] tags)
    {
        return await _dbSet.Where(p => p.Tags.Any(tag => tags.Contains(tag.TagName))).ToListAsync();
    }

    public async Task<IEnumerable<PostEntity>> GetByCreatedDateAsync(bool ascending = true)
    {
        return ascending
            ? await _dbSet.OrderBy(p => p.CreatedAt).ToListAsync()
            : await _dbSet.OrderByDescending(p => p.CreatedAt).ToListAsync();
    }

    public async Task<IEnumerable<PostEntity>> GetByDurationAsync(uint durationInMinutes)
    {
        return await _dbSet.Where(p => p.DurationInMinutes == durationInMinutes).ToListAsync();
    }

    public async Task<IEnumerable<PostEntity>> GetByWatchersAsync(uint watchers, bool ascending = false)
    {
        return ascending
            ? await _dbSet.Where(p => p.Watchers <= watchers).OrderBy(p => p.Watchers).ToListAsync()
            : await _dbSet.Where(p => p.Watchers >= watchers).OrderByDescending(p => p.Watchers).ToListAsync();
    }

    public async Task<IEnumerable<PostEntity>> GetByLikesAsync(uint likes, bool ascending = true)
    {
        return ascending
            ? await _dbSet.Where(p => p.Likes >= likes).OrderBy(p => p.Likes).ToListAsync()
            : await _dbSet.Where(p => p.Likes <= likes).OrderByDescending(p => p.Likes).ToListAsync();
    }

    public async Task<IEnumerable<PostEntity>> GetByDislikesAsync(uint dislikes, bool ascending = true)
    {
        return ascending
            ? await _dbSet.Where(p => p.Dislikes >= dislikes).OrderBy(p => p.Dislikes).ToListAsync()
            : await _dbSet.Where(p => p.Dislikes <= dislikes).OrderByDescending(p => p.Dislikes).ToListAsync();
    }
}
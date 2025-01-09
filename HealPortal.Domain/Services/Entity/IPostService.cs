using HealPortal.Domain.Models.Dtos;

namespace HealPortal.Domain.Services.Entity;

public interface IPostService
{
    Task<bool> CreateAsync(Guid userId, string title, string content, string[] tags, uint durationInMinutes);
    Task<bool> DeleteAsync(Guid userId, Guid postId);
    Task<bool> UpdateAsync(Guid userId, Guid postId, string? title, string? content, string[]? tags, uint? durationInMinutes);
    Task<IEnumerable<PostDto>> GetPostsAsync(Guid userId);
    Task<IEnumerable<PostDto>> GetPostsAsync();
    Task<IEnumerable<PostDto>> GetPostsAsync(string[] tags);
    Task<PostDto> GetByIdAsync(Guid id);
    Task<bool> LikeAsync(Guid postId);
    Task<bool> DislikeAsync(Guid postId);
    Task<bool> WatchAsync(Guid postId);
}
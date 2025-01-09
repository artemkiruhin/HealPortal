using HealPortal.Domain.Models.Dtos;

namespace HealPortal.Domain.Services.Entity;

public interface ICommentService
{
    Task<bool> CreateAsync(Guid userId, Guid postId, string content);
    Task<bool> DeleteAsync(Guid userId, Guid commentId);
    Task<bool> UpdateAsync(Guid userId, Guid commentId, string content);
    Task<IEnumerable<CommentDto>> GetCommentsAsync(Guid postId);
    Task<CommentDto> GetByIdAsync(Guid commentId);
}
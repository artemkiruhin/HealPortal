namespace HealPortal.Domain.Models.Dtos;

public record PostDto(
    Guid Id,
    string Username,
    Guid UserId,
    string Title,
    string Content,
    List<CommentDto> Comments,
    List<TagDto> Tags,
    DateTime CreatedAt,
    uint Likes,
    uint Dislikes,
    uint Watchers,
    uint DurationInMinutes,
    DateTime UpdatedAt);
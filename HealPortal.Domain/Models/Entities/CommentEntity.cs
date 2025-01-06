namespace HealPortal.Domain.Models.Entities;

public class CommentEntity
{
    protected CommentEntity() { }
    public Guid Id { get; protected set; }
    public required string Content { get; set; }
    public virtual PostEntity? Post { get; protected set; }
    public Guid PostId { get; set; }
    public Guid UserId { get; set; }
    public virtual UserEntity? User { get; protected set; }
    public DateTime CreatedAt { get; protected set; }

    public static CommentEntity Create(string content, Guid postId, Guid userId)
    {
        return new()
        {
            Id = Guid.NewGuid(),
            Content = content,
            PostId = postId,
            UserId = userId,
            CreatedAt = DateTime.UtcNow
        };
    }
}
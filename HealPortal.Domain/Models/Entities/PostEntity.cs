namespace HealPortal.Domain.Models.Entities;

public class PostEntity
{
    protected PostEntity() { }
    
    public Guid Id { get; protected set; }
    public required string Title { get; set; }
    public required string Content { get; set; }
    public virtual ICollection<TagEntity>? Tags { get; protected set; }
    public virtual ICollection<CommentEntity>? Comments { get; protected set; }
    public uint Likes { get; set; }
    public uint Dislikes { get; set; }
    public uint Watchers { get; set; }
    public uint DurationInMinutes { get; set; }
    public DateTime CreatedAt { get; protected set; }
    public DateTime? UpdatedAt { get; protected set; }

    public static PostEntity Create(string title, string content, uint durationInMinutes, ICollection<TagEntity>? tags = null)
    {
        return new()
        {
            Id = Guid.NewGuid(),
            Title = title,
            Content = content,
            Tags = tags ?? new List<TagEntity>(),
            Comments = new List<CommentEntity>(),
            DurationInMinutes = durationInMinutes,
            CreatedAt = DateTime.UtcNow
        };
    }
    public void Update()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}
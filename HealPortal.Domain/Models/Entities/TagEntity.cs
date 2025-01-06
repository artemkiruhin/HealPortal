namespace HealPortal.Domain.Models.Entities;

public class TagEntity
{
    protected TagEntity() { }
    public Guid Id { get; protected set; }
    public required string TagName { get; set; }
    public virtual ICollection<PostEntity>? Posts { get; protected set; }
    
    public static TagEntity Create(string tagName)
    {
        return new()
        {
            Id = Guid.NewGuid(),
            TagName = tagName,
            Posts = new List<PostEntity>()
        };
    }
}
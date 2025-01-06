namespace HealPortal.Domain.Models.Entities;

public class UserEntity
{
    protected UserEntity() { }
    
    public Guid Id { get; protected set; }
    public required string Username { get; set; }
    public required string PasswordHash { get; set; }
    public virtual ICollection<CommentEntity>? Comments { get; protected set; }
    public string? Img { get; set; }
    public required string Role { get; set; }
    public DateTime RegisteredAt { get; protected set; }
    
    public static UserEntity Create(string username, string passwordHash, string? img, UserRole? role = null)
    {
        return new()
        {
            Id = Guid.NewGuid(),
            Username = username,
            PasswordHash = passwordHash,
            Comments = new List<CommentEntity>(),
            Img = img,
            Role = role switch
            {
                UserRole.Admin => "Admin",
                UserRole.User => "User",
                UserRole.Editor => "Editor",
                _ => "User" 
            },
            RegisteredAt = DateTime.UtcNow
        };
    }
}
namespace HealPortal.Domain.Models.Dtos;

public record CommentDto(Guid Id, string Content, string Username, string? UserImg, DateTime CreatedAt);
namespace HealPortal.Domain.Models.Dtos;

public record UserDto(Guid Id, string Username, string Role, DateTime RegisteredAt, string? Img, List<PostDto> Posts);
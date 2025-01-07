namespace HealPortal.Domain.Services;

public interface IJwtService
{
    string GenerateToken(Guid userId);
    bool ValidateToken(string token);
}
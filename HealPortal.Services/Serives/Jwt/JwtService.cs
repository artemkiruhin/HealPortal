using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HealPortal.Domain.Services;
using Microsoft.IdentityModel.Tokens;

namespace HealPortal.Services.Serives.Jwt;

public class JwtService : IJwtService
{
    private readonly string _audience;
    private readonly string _issuer;
    private readonly string _key;
    private readonly int _expiresInHours;

    public JwtService(string audience, string issuer, string key, int expiresInHours)
    {
        _audience = audience;
        _issuer = issuer;
        _key = key;
        _expiresInHours = expiresInHours;
    }

    public string GenerateToken(Guid userId)
    {
        var claims = new Claim[]
        {
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Sub, userId.ToString()),
        };
        
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
        var creds = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _issuer,
            audience: _audience,
            claims: claims,
            expires: DateTime.Now.AddHours(_expiresInHours),
            signingCredentials: creds
        );
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public bool ValidateToken(string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_key);

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidIssuer = _issuer,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ClockSkew = TimeSpan.Zero
            };
            
            tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
            
            return true;

        }
        catch (Exception e)
        {
            return false;
        }
    }
}
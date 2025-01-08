using System.Security.Cryptography;
using System.Text;
using HealPortal.Domain.Services;
using static System.Security.Cryptography.SHA256;

namespace HealPortal.Services.Serives.Hasher;

public class Sha256Hasher : IHashService
{
    public string Hash(string message)
        => Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(message)));
}
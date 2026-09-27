using AuthApi.Application.Interfaces;
using AuthApi.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace AuthApi.Infrastructure.Security;

public sealed class PasswordHasher : IPasswordHasher
{
    private readonly PasswordHasher<User> _hasher = new();

    public string Hash(string password)
    {
        return _hasher.HashPassword(null!, password);      
    }

    public bool Verify(string password, string passwordHash)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(password);
        ArgumentException.ThrowIfNullOrWhiteSpace(passwordHash);

        var result = _hasher.VerifyHashedPassword(null!, passwordHash, password);

        return result == PasswordVerificationResult.Success ||
             result == PasswordVerificationResult.SuccessRehashNeeded;
    }
}

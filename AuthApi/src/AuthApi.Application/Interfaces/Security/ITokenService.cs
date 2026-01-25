using AuthApi.Domain.Entities;

namespace AuthApi.Application.Interfaces.Security;

public interface ITokenService
{
    string GenerateToken(User user, IEnumerable<string> roles);
}
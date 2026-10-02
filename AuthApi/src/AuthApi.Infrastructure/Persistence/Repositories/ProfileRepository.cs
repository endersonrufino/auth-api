using AuthApi.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AuthApi.Infrastructure.Persistence.Repositories;

public sealed class ProfileRepository : IProfileRepository
{
    private readonly AuthDbContext _context;

    public ProfileRepository(AuthDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ExistsAsync(long profileId, CancellationToken cancellationToken)
    {
        return await _context.Profiles
            .AnyAsync(x => x.Id == profileId && x.EnabledAt == null, cancellationToken);
    }
}

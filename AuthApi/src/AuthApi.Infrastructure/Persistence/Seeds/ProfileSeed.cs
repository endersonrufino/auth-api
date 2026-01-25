using AuthApi.Domain.Entities;

namespace AuthApi.Infrastructure.Persistence.Seeds;

public static class ProfileSeed
{
    public static readonly Guid AdminId =
        Guid.Parse("11111111-1111-1111-1111-111111111111");

    public static readonly Guid UserId =
        Guid.Parse("22222222-2222-2222-2222-222222222222");

    public static IEnumerable<Profile> Data =>
        new[]
        {
            new Profile { Id = AdminId, Name = "Admin" },
            new Profile { Id = UserId, Name = "User" }
        };
}



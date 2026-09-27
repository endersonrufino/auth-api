namespace AuthApi.Domain.Entities;

public class UserProfile
{
    private UserProfile()
    {
    }

    public UserProfile(long profileId)
    {
        ProfileId = profileId;
        CreatedAt = DateTime.UtcNow;
    }

    public long UserId { get; private set; }

    public long ProfileId { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public User User { get; private set; } = null!;

    public Profile Profile { get; private set; } = null!;
}

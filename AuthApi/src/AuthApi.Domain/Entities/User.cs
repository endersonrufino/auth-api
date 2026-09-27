namespace AuthApi.Domain.Entities;

public class User
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public bool Enable { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime EnabledAt { get; set; }

    public ICollection<UserProfile> UserProfiles { get; private set; } = [];

    private User() { }

    public User(string name, string email, string passwordHash)
    {
        Name = name;
        Email = email;
        PasswordHash = passwordHash;

        Enable = true;
        CreatedAt = DateTime.UtcNow;
    }

    public void AddProfile(long profileId)
    {
        UserProfiles.Add(new UserProfile(Id, profileId));
    }
}

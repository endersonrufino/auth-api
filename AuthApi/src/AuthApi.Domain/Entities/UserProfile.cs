namespace AuthApi.Domain.Entities;

public class UserProfile
{
    public UserProfile(long user_id, long profile_id)
    {
        User_id = user_id;
        Profile_id = profile_id;
        CreatedAt = DateTime.UtcNow;
    }

    public long User_id { get; set; }
    public long Profile_id { get; set; }
    public DateTime CreatedAt { get; set; }
}

using AuthApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthApi.Infrastructure.Persistence.Configurations
{
    public sealed class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(
        EntityTypeBuilder<UserProfile> builder)
        {
            builder.ToTable("user_profile");

            builder.HasKey(x => new
            {
                x.User_id,
                x.Profile_id
            });

            builder.Property(x => x.User_id)
                .HasColumnName("user_id")
                .IsRequired();

            builder.Property(x => x.Profile_id)
                .HasColumnName("profile_id")
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(x => x.User_id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<Profile>()
                .WithMany()
                .HasForeignKey(x => x.Profile_id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

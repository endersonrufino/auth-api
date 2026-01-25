using AuthApi.Domain.Entities;
using AuthApi.Infrastructure.Persistence.Seeds;
using Microsoft.EntityFrameworkCore;

namespace AuthApi.Infrastructure.Persistence;

public class AuthDbContext : DbContext
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Profile> Profiles => Set<Profile>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AuthDbContext).Assembly);

        modelBuilder.Entity<Profile>().HasData(ProfileSeed.Data);
    }
}


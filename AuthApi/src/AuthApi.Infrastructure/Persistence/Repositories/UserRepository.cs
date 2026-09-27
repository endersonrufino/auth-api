using AuthApi.Application.Interfaces;
using AuthApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthApi.Infrastructure.Persistence.Repositories;

public sealed class UserRepository : IUserRepository
{
    private readonly AuthDbContext _context;

    public UserRepository(AuthDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(User usuario, CancellationToken cancellationToken)
    {
        await _context.Users.AddAsync(usuario, cancellationToken);

        //await _context.SaveChangesAsync(cancellationToken);
    }

    public Task DeleteAsync(long id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await _context.Users
         .AnyAsync(x => x.Email.ToLower() == email.ToLower() && x.EnabledAt == null, cancellationToken);
    }

    public Task<IReadOnlyList<User>> GetAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByIdAsync(long id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(User usuario, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

using AuthApi.Application.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace AuthApi.Infrastructure.Persistence.Configurations;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly AuthDbContext _context;
    private IDbContextTransaction _transaction;

    public UnitOfWork(AuthDbContext context)
    {
        _context = context;
    }

    public async Task BeginTransactionAsync(CancellationToken cancellationToken)
    {
        _transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task CommitTransactionAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);

        if (_transaction is not null)
        {
            await _transaction.CommitAsync(cancellationToken);
        }
    }

    public async Task RollbackTransactionAsync(CancellationToken cancellationToken)
    {
        if (_transaction is not null)
        {
            await _transaction.RollbackAsync(cancellationToken);
        }
    }
}

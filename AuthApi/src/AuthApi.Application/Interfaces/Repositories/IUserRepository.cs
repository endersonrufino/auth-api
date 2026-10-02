using AuthApi.Domain.Entities;

namespace AuthApi.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(long id, CancellationToken cancellationToken);

        Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);

        Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken);

        Task<IReadOnlyList<User>> GetAllAsync(CancellationToken cancellationToken);

        Task AddAsync(User usuario, CancellationToken cancellationToken);

        Task UpdateAsync(User usuario, CancellationToken cancellationToken);

        Task DeleteAsync(long id, CancellationToken cancellationToken);
    }
}

namespace AuthApi.Application.Interfaces.Repositories;

public interface IProfileRepository
{
    Task<bool> ExistsAsync(long perfilId, CancellationToken cancellationToken);
}

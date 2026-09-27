namespace AuthApi.Application.Interfaces;

public interface IProfileRepository
{
    Task<bool> ExistsAsync(long perfilId, CancellationToken cancellationToken);
}

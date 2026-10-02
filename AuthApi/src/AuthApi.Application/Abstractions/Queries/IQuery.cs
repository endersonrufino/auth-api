using MediatR;

namespace AuthApi.Application.Abstractions.Queries;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}

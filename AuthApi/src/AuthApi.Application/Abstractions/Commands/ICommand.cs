using MediatR;

namespace AuthApi.Application.Abstractions.Commands;

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}

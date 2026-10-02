using MediatR;

namespace AuthApi.Application.Auth.Commands.Login;

public sealed record LoginCommand(string Email, string Password) : IRequest;

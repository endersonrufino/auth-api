using MediatR;

namespace AuthApi.Application.Users.Commands.CreateUser;

public sealed record CreateUserCommand(string Name, string Email, string Password, long ProfileId) : IRequest<long>;

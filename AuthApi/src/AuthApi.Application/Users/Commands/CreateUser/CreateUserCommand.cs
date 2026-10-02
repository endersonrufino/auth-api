using AuthApi.Application.Abstractions.Commands;

namespace AuthApi.Application.Users.Commands.CreateUser;

public sealed record CreateUserCommand(string Name, string Email, string Password, long ProfileId) : ICommand<long>;

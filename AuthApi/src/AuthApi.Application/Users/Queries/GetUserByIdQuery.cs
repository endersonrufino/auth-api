using AuthApi.Application.Abstractions.Queries;

namespace AuthApi.Application.Users.Queries;

public sealed record GetUserByIdQuery(long UserId) : IQuery<UserResponse>;


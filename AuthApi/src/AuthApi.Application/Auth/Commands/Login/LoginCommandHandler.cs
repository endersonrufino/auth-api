using AuthApi.Application.Interfaces;
using AuthApi.Application.Interfaces.Repositories;
using MediatR;

namespace AuthApi.Application.Auth.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public LoginCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);

        if (user is null)
        {
            throw new InvalidOperationException("Email ou senha invalido");
        }

        var validPassword = _passwordHasher.Verify(request.Password, user.PasswordHash);

        if (!validPassword)
        {
            throw new InvalidOperationException("Email ou senha invalido");
        }






    }
}

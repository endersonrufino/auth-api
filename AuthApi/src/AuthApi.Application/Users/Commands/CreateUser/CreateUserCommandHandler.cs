using AuthApi.Application.Interfaces;
using AuthApi.Domain.Entities;
using MediatR;

namespace AuthApi.Application.Users.Commands.CreateUser;

public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, long>
{
    private readonly IUserRepository _usuarioRepository;
    private readonly IProfileRepository _profileRepository;
    private readonly IPasswordHasher _passwordHasher;

    public CreateUserCommandHandler(IUserRepository usuarioRepository, IProfileRepository profileRepository, IPasswordHasher passwordHasher)
    {
        _usuarioRepository = usuarioRepository;
        _profileRepository = profileRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<long> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var existsEmail = await _usuarioRepository.ExistsByEmailAsync(request.Email, cancellationToken);

        if (existsEmail)
        {
            throw new InvalidOperationException("Já existe um usuário com este e-mail.");
        }

        var profile = await _profileRepository.ExistsAsync(request.ProfileId, cancellationToken);

        if (!profile)
        {
            throw new InvalidOperationException("O perfil informado não existe.");
        }

        var passwordHash = _passwordHasher.Hash(request.Password);

        var user = new User(request.Name, request.Email, passwordHash);
        user.AddProfile(request.ProfileId);
       
        await _usuarioRepository.AddAsync(user, cancellationToken);

        return user.Id;
    }
}

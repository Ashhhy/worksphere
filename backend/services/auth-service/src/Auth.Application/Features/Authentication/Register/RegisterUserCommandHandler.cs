using MediatR;
using Auth.Application.Interfaces.Persistence;
using Auth.Application.Interfaces.Security;
using Auth.Domain.ValueObjects;
using Auth.Domain.Entities;

namespace Auth.Application.Features.Authentication.Register;

public sealed class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterUserResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public RegisterUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;

    }

    public async Task<RegisterUserResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var email = Email.Create(request.Email);
        var exists = await _userRepository.ExistsByEmailAsync(email, cancellationToken);
        if (exists)
            throw new DuplicateEmailException(email.Value);
        var passwordHash = _passwordHasher.Hash(request.Password);
        var user = new User(Guid.NewGuid(), request.FirstName, request.LastName, email, passwordHash);

        await _userRepository.AddAsync(user, cancellationToken);

        return new RegisterUserResponse(Guid.Empty, "Registration completed successfully.");
        
    }
}
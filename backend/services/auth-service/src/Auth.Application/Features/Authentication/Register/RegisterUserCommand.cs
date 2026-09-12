using MediatR;

namespace Auth.Application.Features.Authentication.Register;

public sealed record RegisterUserCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password
) : IRequest<RegisterUserResponse>;

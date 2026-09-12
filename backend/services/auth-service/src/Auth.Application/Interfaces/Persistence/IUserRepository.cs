using Auth.Domain.ValueObjects;
using Auth.Domain.Entities;

namespace Auth.Application.Interfaces.Persistence;

public interface IUserRepository
{
    Task<bool> ExistsByEmailAsync(Email email, CancellationToken cancellationToken);

    Task AddAsync(User user, CancellationToken cancellationToken);
}
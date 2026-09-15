using Auth.Application.Interfaces.Security;

namespace Auth.Infrastructure.Security;

public sealed class PasswordHasher : IPasswordHasher
{
    public string Hash(string password)
    {
        throw new NotImplementedException();
    }
    public bool Verify(string password, string passwordHash)
    {
        throw new NotImplementedException();
    }
}
namespace Auth.Domain.Exceptions;

public sealed class InvalidEmailException : DomainException
{
    public InvalidEmailException(string email) : base($"Invalid email: {email}")
    {
    }
}
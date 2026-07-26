namespace Auth.Domain.Exceptions;

public sealed class InvalidFirstNameException : DomainException
{
    public InvalidFirstNameException(string message) : base(message)
    {
    }
}
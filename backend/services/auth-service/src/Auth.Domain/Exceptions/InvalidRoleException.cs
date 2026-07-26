namespace Auth.Domain.Exceptions;

public sealed class InvalidRoleException : DomainException
{
    public InvalidRoleException(string role) : base($"Invalid role: {role}")
    { 
    }
}
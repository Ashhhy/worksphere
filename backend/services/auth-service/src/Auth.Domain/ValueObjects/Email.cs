using System.Text.RegularExpressions;
using Auth.Domain.Exceptions;

namespace Auth.Domain.ValueObjects;

public sealed class Email
{
    public string Value { get; }
    private Email(string value)
    {
        Value = value;
    }

    public static Email Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidEmailException(value);

        if (!IsValid(value))
            throw new InvalidEmailException(value);

        return new Email(value.Trim().ToLowerInvariant());

    }
    private static bool IsValid(string email)
    {
        return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    }
    public override string ToString()
    {
        return Value;
    }
}
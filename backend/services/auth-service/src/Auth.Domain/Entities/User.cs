using Auth.Domain.Enums;
using Auth.Domain.Common;
using Auth.Domain.ValueObjects;
using Auth.Domain.Exceptions;
using Auth.Domain.Constants;

namespace Auth.Domain.Entities;

public class User : BaseEntity
{
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public Email Email { get; private set; }
    public string PasswordHash { get; private set; } = string.Empty;
    public UserRole Role { get; private set; }
    public UserStatus Status { get; private set; }
    public DateTime? LastLoginAt { get; private set; }

    private User()
    {
        //for EF Core
    }
    public User(Guid id, string firstName, string lastName, Email email, string passwordHash) : base(id)
    {
        ValidateFirstName(firstName);
        ValidateLastName(lastName);

        FirstName = firstName.Trim();
        LastName = lastName.Trim();
        Email = email;
        PasswordHash = passwordHash;

        Role = UserRole.Employee;
        Status = UserStatus.PendingVerification;
    }

    // ========================
    // Domain behaviour
    // ========================

    public void Activate()
    {
        Status = UserStatus.Active;
        MarkAsUpdated();
    }
    public void Lock()
    {
        Status = UserStatus.Locked;
        MarkAsUpdated();
    }
    public void RecordLogin()
    {
        LastLoginAt = DateTime.UtcNow;
        MarkAsUpdated();
    }
    public void ChangeRole(UserRole role)
    {
        Role = role;
        MarkAsUpdated();
    }

    private static void ValidateFirstName(string firstName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new InvalidFirstNameException("First Name is required");
        if (firstName.Length > UserConstants.FirstNameMaxLength)
            throw new InvalidFirstNameException($"First Name cannot exceed {UserConstants.FirstNameMaxLength} characters");
    }
    private static void ValidateLastName(string lastName)
    {
        if (string.IsNullOrWhiteSpace(lastName))
            throw new InvalidLastNameException("Last Name is required");
        if (lastName.Length > UserConstants.LastNameMaxLength)
            throw new InvalidLastNameException($"Last Name cannot exceed {UserConstants.LastNameMaxLength} characters");
    }
}
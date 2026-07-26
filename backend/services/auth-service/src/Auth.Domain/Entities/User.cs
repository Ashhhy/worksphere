using Auth.Domain.Enums;
using Auth.Domain.Common;
using Auth.Domain.ValueObjects;
using Auth.Domain.Exceptions;

namespace Auth.Domain.Entities;

public class User : BaseEntity
{
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public Email Email { get; private set; }
    public string PasswordHash { get; private set; } = string.Empty;
    public UserRole Role { get; private set; }
    public UserStatus Status { get; private set; }
    public DateTime? UpdateAt { get; private set; }
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
        MarkasUpdated();
    }
    public void Lock()
    {
        Status = UserStatus.Locked;
        MarkasUpdated();
    }
    public void RecordLogin()
    {
        LastLoginAt = DateTime.UtcNow;
        MarkasUpdated();
    }
    public void ChangeRole(UserRole role)
    {
        Role = role;
        MarkasUpdated();
    }

    private static void ValidateFirstName(string firstName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new InvalidFirstNameException("First Name is required");
        if (firstName.Length > UserConstants.FirstNameMaxLength)
            throw new InvalidFirstNameException($"First Name cannot exceed {UserConstants.FirstNameMaxLength} characters");
    }
    private static void ValidateLastName(string firstName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new InvalidLastNameException("Last Name is required");
        if (firstName.Length > UserConstants.FirstNameMaxLength)
            throw new InvalidLastNameException($"Last Name cannot exceed {UserConstants.FirstNameMaxLength} characters");
    }
}
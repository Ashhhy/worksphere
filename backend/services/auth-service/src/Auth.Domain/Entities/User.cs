using Auth.Domain.Enums;
using Auth.Domain.Common;

namespace Auth.Domain.Entities;

public class User : BaseEntity
{
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string PasswordHash { get; private set; } = string.Empty;
    public UserRole Role { get; private set; }
    public UserStatus Status { get; private set; }
    public DateTime? UpdateAt { get; private set; }
    public DateTime? LastLoginAt { get; private set; }

    private User()
    {
        //for EF Core
    }
    public User(Guid id, string firstName, string lastName, string email, string passwordHash) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
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
}
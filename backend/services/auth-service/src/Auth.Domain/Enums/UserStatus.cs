namespace Auth.Domain.Enums;

public enum UserStatus
{
    PendingVerification = 0,
    Active = 1,
    Inactive = 2,
    Locked = 3,
    Deleted = 4
}
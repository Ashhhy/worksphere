namespace Auth.Domain.Common;

public abstract class BaseEntity
{
    public Guid Id { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
    public DateTime? UpdatedAt { get; protected set; }
    protected BaseEntity()
    {
        //Req by EF Core
    }
    protected BaseEntity(Guid id)
    {
        Id = id;
        CreatedAt = DateTime.UtcNow;
    }
    protected void MarkAsUpdated()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}


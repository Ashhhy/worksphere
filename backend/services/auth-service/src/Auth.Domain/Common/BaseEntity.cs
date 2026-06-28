namespace Auth.Domain.Common;

public abstract class BaseEntity
{
    public Guid Id { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
    public DateTime? UpdatedAt { get; protected set; }
    protected BaseEntity()
    {

    }
    protected BaseEntity(Guid id)
    {
        Id = id;
        CreatedAt = DateTime.UtcNow;
    }
    protected void MarkasUpdated()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}


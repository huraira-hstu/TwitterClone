namespace TwitterClone.Domain.Entities
{
  public abstract class BaseEntity
  {
    public Guid Id {get; protected set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; protected set; } = DateTime.UtcNow;

    protected BaseEntity() {}

    protected BaseEntity(Guid id)
    {
      this.Id = id;
    }

    protected BaseEntity(Guid id, DateTime createdAt)
    {
      this.Id = id;
      this.CreatedAt = createdAt;
    }

    protected BaseEntity(Guid id, DateTime createdAt, DateTime updatedAt)
    {
      this.Id = id;
      this.CreatedAt = createdAt;
      this.UpdatedAt = updatedAt;
    }

    protected void _updated()
    {
      this.UpdatedAt = DateTime.UtcNow;
    }

  }
}
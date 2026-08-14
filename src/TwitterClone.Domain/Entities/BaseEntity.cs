namespace TwitterClone.Domain.Entities;

public abstract class BaseEntity
{
  public Guid Id { get; protected set; }
  public DateTime CreatedAt { get; protected set; }
  public Guid CreatedBy { get; protected set; }
  public DateTime? ModifiedAt { get; protected set; }
  public Guid? ModifiedBy { get; protected set; }

  protected BaseEntity(
    Guid id,
    DateTime createdAt,
    Guid createdBy,
    DateTime? modifiedAt = null,
    Guid? modifiedBy = null
  )
  {
    Id = id;
    CreatedAt = createdAt;
    CreatedBy = createdBy;
    ModifiedAt = modifiedAt;
    ModifiedBy = modifiedBy;
  }

  public virtual string DescribeRecord()
  {
    return $"""
    {GetType().Name}:
      Id: {Id} 
      CreatedAt: {CreatedAt}
      ModifiedAt: {ModifiedAt}
      CreatedBy: {CreatedBy}
      ModifiedBy: {ModifiedBy}
    """;
  }

}
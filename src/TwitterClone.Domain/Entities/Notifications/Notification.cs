namespace TwitterClone.Domain.Entities.Notifications;

public abstract class Notification : BaseEntity
{

  public Guid UserId {get; private set;}
  public string Content {get; protected set;}
  public bool IsRead { get;  protected set; }
  public string Type { get; }


  public Notification(
    Guid id,
    Guid userId,
    string content,
    string type,
    DateTime createdAt,
    Guid createdBy,
    DateTime? modifiedAt = null, 
    Guid? modifiedBy = null
  ) : base(id, createdAt, createdBy, modifiedAt, modifiedBy)
  {
    UserId = userId;
    Content = content;
    Type = type;
  }
 
  public override string DescribeRecord()
  {
    return $"""
    {base.DescribeRecord()}
      UserId: {UserId}
      Content: {Content}
      Type: {Type}
    """;
  }
}
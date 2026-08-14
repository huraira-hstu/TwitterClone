namespace TwitterClone.Domain.Entities;

public class Message : BaseEntity
{

  public Guid SenderId { get; private set;}
  public Guid ReceiverId { get; private set; }
  public string Content { get; private set; }
  public DateTime SentAt { get; private set; }

  public Message(
    Guid id,
    Guid senderId, 
    Guid receiverId,
    string content,
    DateTime sentAt,
    DateTime createdAt, 
    Guid createdBy, 
    DateTime? modifiedAt = null, 
    Guid? modifiedBy = null
  ) : base(id, createdAt, createdBy, modifiedAt, modifiedBy)
  {
    SenderId = senderId;
    ReceiverId = receiverId;
    Content = content;
    SentAt = sentAt;
  }


  public override string DescribeRecord()
  {
    return $"""
    {base.DescribeRecord()}
      SenderId: {SenderId}
      ReceiverId: {ReceiverId}
      Content: {Content}
      SentAt: {SentAt:HH:mm:ss dd/MM/yyyy}
    """;
  }
}
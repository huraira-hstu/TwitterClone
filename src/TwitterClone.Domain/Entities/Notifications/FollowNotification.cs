namespace TwitterClone.Domain.Entities.Notifications;

public sealed class FollowNotification : Notification
{
  public Guid FollowedByUserId { get; private set; }
  

  public FollowNotification(
    Guid id, 
    Guid userId,
    string content, 
    Guid followedBy,
    DateTime createdAt, 
    Guid createdBy, 
    DateTime? modifiedAt = null, 
    Guid? modifiedBy = null
  ) : base(id, userId, content, "Follow", createdAt, createdBy, modifiedAt, modifiedBy)
  {
    FollowedByUserId = followedBy;
  }

  public void SetContent(string content)
  {
    Content = content;
  }
  

  public override string GetNotification()
  {
    return $"User with ID{FollowedByUserId} followed you";
  }

  public override string DescribeRecord()
  {
    return $"""
    {base.DescribeRecord()}
      FollowedByUserId: {FollowedByUserId}
    """;
  }
  
}
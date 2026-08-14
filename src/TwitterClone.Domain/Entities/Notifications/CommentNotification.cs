namespace TwitterClone.Domain.Entities.Notifications;

public sealed class CommentNotification : Notification
{
  public Guid CommentedByUserId { get; private set; }
  public Guid TweetId { get; private set; }

  public CommentNotification(
    Guid id, 
    Guid userId,
    string content, 
    Guid commentedBy,
    Guid tweetId,
    DateTime createdAt, 
    Guid createdBy, 
    DateTime? modifiedAt = null, 
    Guid? modifiedBy = null
  ) : base(id, userId, content, "Comment", createdAt, createdBy, modifiedAt, modifiedBy)
  {
    CommentedByUserId = commentedBy;
    TweetId = tweetId;
  }


  public void SetNotificationContent(
    string commentedBy,
    string tweet,
    string comment
  )
  {
    Content = $"{commentedBy} commented in your tweet: {tweet}\n{comment}";
  }

  public override string DescribeRecord()
  {
    return $"""
    {base.DescribeRecord()}
      TweetId: {TweetId}
      CommentedByUserID: {CommentedByUserId}
    """;
  }
  
}
namespace TwitterClone.Domain.Entities.Notifications;

public sealed class FollowNotification : Notification
{
  public Guid FollowedByUserId { get; private set; }
  public Guid TweetId { get; private set;}

  public FollowNotification(
    Guid id, 
    Guid userId,
    string content, 
    Guid followedBy,
    Guid tweetId,
    DateTime createdAt, 
    Guid createdBy, 
    DateTime? modifiedAt = null, 
    Guid? modifiedBy = null
  ) : base(id, userId, content, "Follow", createdAt, createdBy, modifiedAt, modifiedBy)
  {
    FollowedByUserId = followedBy;
    TweetId = tweetId;
  }


  public void SetNotificationContent(
    string FollowdBy,
    string tweetContent
  )
  {
    Content = $"{FollowdBy} Followd your tweet: {tweetContent}";
  }
 
  public override string DescribeRecord()
  {
    return $"""
    {base.DescribeRecord()}
      TweetId: {TweetId}
      FollowedByUserId: {FollowedByUserId}
    """;
  }
  
}
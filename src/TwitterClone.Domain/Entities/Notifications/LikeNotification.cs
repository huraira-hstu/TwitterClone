namespace TwitterClone.Domain.Entities.Notifications;

public sealed class LikeNotification : Notification
{
  public Guid LikedByUserId { get; private set; }
  public Guid TweetId { get; private set;}

  public LikeNotification(
    Guid id, 
    Guid userId,
    string content, 
    Guid likedBy,
    Guid tweetId,
    DateTime createdAt, 
    Guid createdBy, 
    DateTime? modifiedAt = null, 
    Guid? modifiedBy = null
  ) : base(id, userId, content, "Like", createdAt, createdBy, modifiedAt, modifiedBy)
  {
    LikedByUserId = likedBy;
    TweetId = tweetId;
  }


  public void SetNotificationContent(
    string likedBy,
    string tweetContent
  )
  {
    Content = $"{likedBy} liked your tweet: {tweetContent}";
  }
 
  public override string DescribeRecord()
  {
    return $"""
    {base.DescribeRecord()}
      TweetId: {TweetId}
      LikedByUserId: {LikedByUserId}
    """;
  }
  
}
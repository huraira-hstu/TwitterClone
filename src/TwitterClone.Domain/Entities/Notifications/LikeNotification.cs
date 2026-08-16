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
 
  public void SetContent(string content)
  {
    Content = content;
  }
  
  public override string GetNotification()
  {
    return $"User with ID {LikedByUserId} liked your post.";
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
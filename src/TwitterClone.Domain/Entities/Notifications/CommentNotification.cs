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

  public void SetContent(string content)
  {
    Content = content;
  }
  
  public override string GetNotification()
  {
    return $"User with userID:{CommentedByUserId} comented your tweet with tweetID:{TweetId}";
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
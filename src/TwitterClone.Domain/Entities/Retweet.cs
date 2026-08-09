namespace TwitterClone.Domain.Entities;

public class Retweet : BaseEntity
{

  public Guid UserId {get; private set;}
  public Guid TweetId {get; private set;}
  
  public Retweet(
    Guid retweetId,
    Guid userId, 
    Guid tweetId,
    DateTime createdAt,
    DateTime updatedAt
  ) : base(retweetId, createdAt, updatedAt)
  {
    UserId = userId;
    TweetId = tweetId;
  }

  public Retweet(
    Guid userId, 
    Guid tweetId
  ) : base()
  {
    UserId = userId;
    TweetId = tweetId;
  }
}
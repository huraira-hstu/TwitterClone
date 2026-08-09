namespace TwitterClone.Domain.Entities;

public class Bookmark
{
  public Guid UserId { get; private set; }
  public Guid TweetId { get; private set; }

  private Bookmark() {}
  public Bookmark(Guid userId, Guid tweetId)
  {
    UserId = userId;
    TweetId = tweetId;
  } 
}
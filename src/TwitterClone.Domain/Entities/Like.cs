namespace TwitterClone.Domain.Entities
{
  public class Like
  { 
    public Guid UserId { get; init;}
    public Guid TweetId { get; init;}

    private Like() {} 

    public Like(Guid userId, Guid tweetId)
    {
      this.UserId = userId;
      this.TweetId = tweetId;
    }

  }
}

 
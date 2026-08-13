namespace TwitterClone.Domain.Entities;

public class Retweet:BaseEntity
{
  public Guid UserId { get; private set; }
  public Guid TweetId { get; private set; }
  public string Comment { get; private set; }
  
  public Retweet(
    Guid RetweetId,
    Guid userId,
    Guid tweetId,
    string comment,
    DateTime createdAt,
    Guid createdBy,
    DateTime? modifiedAt = null,
    Guid? modifiedBy = null
  ) : base(RetweetId, createdAt, createdBy, modifiedAt, modifiedBy)
  {
    UserId = userId;
    Comment = comment;
    TweetId = tweetId;
  }

  public override string DescribeRecord()
  {
    return $"""
    {base.DescribeRecord()}
      UserId: {UserId}
      TweetId: {TweetId}
      Comment: {Comment}
    """;
  }
}
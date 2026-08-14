namespace TwitterClone.Domain.Entities;

public class Bookmark:BaseEntity
{
  public Guid UserId { get; private set; }
  public Guid TweetId { get; private set; }
  
  public Bookmark(
    Guid bookmarkId,
    Guid userId,
    Guid tweetId,
    DateTime createdAt,
    Guid createdBy,
    DateTime? modifiedAt = null,
    Guid? modifiedBy = null
  ) : base(bookmarkId, createdAt, createdBy, modifiedAt, modifiedBy)
  {
    UserId = userId;
    TweetId = tweetId;
  }

  public override string DescribeRecord()
  {
    return $"""
    {base.DescribeRecord()}
      UserId: {UserId}
      TweetId: {TweetId}
      
    """;
  }
}
namespace TwitterClone.Domain.Entities;

public class Tweet:BaseEntity
{
  public Guid UserId { get; private set; }
  public string Content { get; private set; }
  
  public Tweet(
    Guid tweetId,
    Guid userId,
    string content,
    DateTime createdAt,
    Guid createdBy,
    DateTime? modifiedAt = null,
    Guid? modifiedBy = null
  ) : base(tweetId, createdAt, createdBy, modifiedAt, modifiedBy)
  {
    UserId = userId;
    Content = content;
  }

  public override string DescribeRecord()
  {
    return $"""
    {base.DescribeRecord()}
      UserId: {UserId}
      Content: {Content}
    """;
  }
}
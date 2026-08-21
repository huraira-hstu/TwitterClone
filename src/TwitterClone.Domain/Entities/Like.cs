using TwitterClone.Domain.Entities.Interfaces;

namespace TwitterClone.Domain.Entities;

public class Like:BaseEntity
{
  public Guid UserId { get; private set; }
  public Guid TweetId { get; private set; }
  
  public Like(
    Guid LikeId,
    Guid userId,
    Guid tweetId,
    DateTime createdAt,
    Guid createdBy,
    DateTime? modifiedAt = null,
    Guid? modifiedBy = null
  ) : base(LikeId, createdAt, createdBy, modifiedAt, modifiedBy)
  {
    UserId = userId;
    TweetId = tweetId;
  }

  public static Like CreateLikeFor(ILikable likable, Guid userId)
  {
    if (!likable.CanBeLiked())
    {
      throw new Exception("cannot be liked");
    }

    return new Like(
      Guid.NewGuid(),
      userId,
      likable.Id,
      DateTime.UtcNow,
      userId
    );
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
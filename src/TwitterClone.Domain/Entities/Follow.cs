namespace TwitterClone.Domain.Entities;

public class Follow:BaseEntity
{
  public Guid FollowerId { get; private set; }
  public Guid FollowingId { get; private set; }
  
  public Follow(
    Guid FollowId,
    Guid followerId,
    Guid followingId,
    DateTime createdAt,
    Guid createdBy,
    DateTime? modifiedAt = null,
    Guid? modifiedBy = null
  ) : base(FollowId, createdAt, createdBy, modifiedAt, modifiedBy)
  {
    FollowerId = followerId;
    FollowingId = followingId;  
  }

  public override string DescribeRecord()
  {
    return $"""
    {base.DescribeRecord()}
      FollowerId: {FollowerId}
      FollowingId: {FollowingId}
    """;
  }
}
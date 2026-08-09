 
using TwitterClone.Domain.Shared;

namespace TwitterClone.Domain.Entities;

public class Follow 
{
  public Guid FollowerId { get; private set; }
  public Guid FolloweeId { get; private set; }
  public DateTime StartedFollowingAt { get; private set; }
  private Follow() {}
  
  public static Result<Follow> Create(Guid followerId, Guid followeeId, DateTime startedFollowingAt)
  {

    if(followerId == followeeId)
    {
      return Result.Failure<Follow>(DomainErrors.Follow.CannotFollowSelf);
    } 
    return Result.Success(
      new Follow{
        FollowerId = followerId,
        FolloweeId = followeeId,
        StartedFollowingAt = startedFollowingAt
      }
    );
  }
}
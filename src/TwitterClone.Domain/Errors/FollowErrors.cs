

using TwitterClone.Domain.Shared;
namespace TwitterClone.Domain.DomainErrors;


public static class Follow
{
  public static readonly Error CannotFollowSelf = new (
    Code: "Follow.CannotFollowSelf",
    Description: ""
  );
}
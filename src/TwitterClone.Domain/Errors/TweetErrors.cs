
using TwitterClone.Domain.Shared;
namespace TwitterClone.Domain.DomainErrors;


public static class Tweet
{
  public static readonly Error InvalidTweetContent = new (
    Code: "Tweet.InvalidTweetContent",
    Description: ""
  );

  public static readonly Error CannotRetweetTwice = new (
    Code: "Tweet.CannotRetweetTwice",
    Description: ""
  );

  public static class Like
  {
    public static readonly Error CannotLikeTwice = new (
      Code: "Tweet.Like.CannotLikeTwice",
      Description: ""
    );

    public static readonly Error CannotUnlikeNotLikedTweet = new (
      Code: "Tweet.Like.CannotUnlikeNotLikedTweet",
      Description: ""
    );

  }
}
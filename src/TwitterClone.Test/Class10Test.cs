
using TwitterClone.Domain.Entities;
using TwitterClone.Domain.Entities.Interfaces;

namespace TwitterClone.Test;

public class Class10Test
{

  public void ProcessLike(ILikable likable)
  {

    Console.WriteLine(likable.CanBeLiked());
    var like = Like.CreateLikeFor(likable, Guid.NewGuid());
    Console.WriteLine(like.DescribeRecord());
  }

  public void Run()
  {
    var userId = Guid.NewGuid();
    var tweetId = Guid.NewGuid();

    var likableTweet = new Tweet(
      tweetId,
      userId,
      "This is another tweet",
      DateTime.UtcNow,
      userId 
    );

    ProcessLike(likableTweet);
  }
}
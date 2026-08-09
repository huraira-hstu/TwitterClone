using TwitterClone.Domain.Shared;
using TwitterClone.Domain.ValueObjects.Tweet;

namespace TwitterClone.Domain.Entities;

public class Tweet : BaseEntity
{
  public Guid AuthorId { get; private set; }
  public TweetContent Content { get; private set; }
  public Guid? ParentTweetId { get; private set; } 
  public bool IsEdited { get; private set; } = false;

  private readonly List<Like> _likes = new();
  private readonly List<Retweet> _retweets = new();

  public IReadOnlyCollection<Like> Likes => _likes.AsReadOnly();
  public IReadOnlyCollection<Retweet> Retweets => _retweets.AsReadOnly();

  public Tweet(
    Guid tweetId,
    Guid authorId, 
    TweetContent content, 
    Guid? parentTweetId,
    DateTime createdAt,
    DateTime updatedAt
  ) : base(tweetId, createdAt, updatedAt)
  {
    AuthorId = authorId;
    Content = content;
    ParentTweetId = parentTweetId;
  }

  public static Result<Tweet> Create(Guid authorId, string rawContent, Guid? parentTweetId = null)
  {
    var contentResult = TweetContent.Create(rawContent);
    if (contentResult.IsFailure)
    {
      return Result.Failure<Tweet>(contentResult.Error);
    }

    return Result.Success(new Tweet(
      Guid.NewGuid(),
      authorId, 
      contentResult.Value, 
      parentTweetId,
      DateTime.UtcNow,
      DateTime.UtcNow
    ));
  }

  public Result<Like> AddLike(Guid userId)
  {
    if (_likes.Any(l => l.UserId == userId))
      return Result.Failure<Like>(DomainErrors.Tweet.Like.CannotLikeTwice);

    var like = new Like(userId, Id);
    _likes.Add(like);
    return Result.Success(like);
  }

  public Result RemoveLike(Guid userId)
  {
    var like = _likes.FirstOrDefault(l => l.UserId == userId);
    if (like == null)
    {
      return Result.Failure(DomainErrors.Tweet.Like.CannotUnlikeNotLikedTweet);
    }

    _likes.Remove(like);
    return Result.Success();
  }

  public Result<Retweet> AddRetweet(Guid userId)
  {
    if (_retweets.Any(r => r.UserId == userId))
    {
      return Result.Failure<Retweet>(DomainErrors.Tweet.CannotRetweetTwice);
    }

    var retweet = new Retweet(userId, Id);
    _retweets.Add(retweet);
    return Result.Success(retweet);
  }

  public Result UpdateTweetConent(string rawContent)
  {
    var contentResult = TweetContent.Create(rawContent);
    if (contentResult.IsFailure)
    {
      return Result.Failure(contentResult.Error);
    }
    this.Content = contentResult.Value;
    this.IsEdited = true;
    
    _updated();
    return Result.Success();
  }
}




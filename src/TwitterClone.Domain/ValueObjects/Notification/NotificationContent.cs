using TwitterClone.Domain.Shared;


namespace TwitterClone.Domain.ValueObjects.Notification
{
  public sealed record NotificationContent
  {
    public const int MaxActorNameLength = 60;
    public const int MaxTitleLength = 120;
    public const int MaxDescriptionLength = 280;

    public string Title { get; }
    public string? Description { get; }

    private NotificationContent(string title, string? description = null)
    {
      Title = title;
      Description = description;
    }

    public static Result<NotificationContent> Create(string? rawTitle, string? rawDescription = null)
    {
      if (string.IsNullOrWhiteSpace(rawTitle))
      {
        return Result.Failure<NotificationContent>(DomainErrors.Notification.InvalidNotificationTitle);
      }

      var trimmedTitle = rawTitle.Trim();

      if (trimmedTitle.Length > MaxTitleLength)
      {
        return Result.Failure<NotificationContent>(DomainErrors.Notification.InvalidNotificationTitle);
      }

      string? trimmedDescription = null;
      if (!string.IsNullOrWhiteSpace(rawDescription))
      {
        trimmedDescription = rawDescription.Trim();
        if (trimmedDescription.Length > MaxDescriptionLength)
        {
            trimmedDescription = trimmedDescription.TruncateByWord(MaxDescriptionLength);
        }
      }

      return Result.Success(new NotificationContent(trimmedTitle, trimmedDescription));
    }
 
    public static NotificationContent CreateForLike(string actorUsername, string? tweetSnippet = null)
    {
      var formattedUser = actorUsername.TruncateByWord(MaxActorNameLength);
      var title = $"@{formattedUser} liked your tweet.";
      var description = tweetSnippet?.TruncateByWord(MaxDescriptionLength);
      return new NotificationContent(title, description);
    }

    public static NotificationContent CreateForFollow(string actorUsername)
    {
      var formattedUser = actorUsername.TruncateByWord(MaxActorNameLength);
      return new NotificationContent($"@{formattedUser} followed you.");
    }

    public static NotificationContent CreateForReply(string actorUsername, string replySnippet)
    {
      var formattedUser = actorUsername.TruncateByWord(MaxActorNameLength);
      var title = $"@{formattedUser} replied to you.";
      var description = replySnippet.TruncateByWord(MaxDescriptionLength);
      return new NotificationContent(title, description);
    }

    public static NotificationContent CreateForRetweet(string actorUsername, string? tweetSnippet = null)
    {
      var formattedUser = actorUsername.TruncateByWord(MaxActorNameLength);
      var title = $"@{formattedUser} retweeted your tweet.";
      var description = tweetSnippet?.TruncateByWord(MaxDescriptionLength);
      return new NotificationContent(title, description);
    }

    public static NotificationContent CreateForMention(string actorUsername, string tweetSnippet)
    {
      var formattedUser = actorUsername.TruncateByWord(MaxActorNameLength);
      var title = $"@{formattedUser} mentioned you in a tweet.";
      var description = tweetSnippet.TruncateByWord(MaxDescriptionLength);
      return new NotificationContent(title, description);
    }

    public static NotificationContent CreateForQuote(string actorUsername, string quoteSnippet)
    {
      var formattedUser = actorUsername.TruncateByWord(MaxActorNameLength);
      var title = $"@{formattedUser} quoted your tweet.";
      var description = quoteSnippet.TruncateByWord(MaxDescriptionLength);
      return new NotificationContent(title, description);
    }

    public static NotificationContent CreateForDirectMessage(string actorUsername, string messageSnippet)
    {
      var formattedUser = actorUsername.TruncateByWord(MaxActorNameLength);
      var title = $"@{formattedUser} sent you a message.";
      var description = messageSnippet.TruncateByWord(MaxDescriptionLength);
      return new NotificationContent(title, description);
    }

    public override string ToString() => string.IsNullOrWhiteSpace(Description) 
      ? Title 
      : $"{Title} - {Description}";
  }
}
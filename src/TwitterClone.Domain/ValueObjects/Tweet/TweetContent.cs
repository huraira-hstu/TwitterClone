using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using TwitterClone.Domain.Shared;


namespace TwitterClone.Domain.ValueObjects.Tweet
{
  public sealed record TweetContent
  {
    public const int MaxCharacterCount = 280;

    private static readonly Regex HashtagRegex = new(
      @"(?<=^|[\s.,!?:;])#([a-zA-Z0-9_]+)",
      RegexOptions.Compiled | RegexOptions.CultureInvariant
    );

    private static readonly Regex MentionRegex = new(
      @"(?<=^|[\s.,!?:;])@([a-zA-Z0-9_]{3,64})",
      RegexOptions.Compiled | RegexOptions.CultureInvariant
    );

    public string Value { get; }
    public IReadOnlyList<string> Hashtags { get; }
    public IReadOnlyList<string> Mentions { get; }

    private TweetContent(string value, List<string> hashtags, List<string> mentions)
    {
      Value = value;
      Hashtags = hashtags.AsReadOnly();
      Mentions = mentions.AsReadOnly();
    }

    public static Result<TweetContent> Create(string? rawInput)
    {
      if (string.IsNullOrWhiteSpace(rawInput))
      {
        return Result.Failure<TweetContent>(DomainErrors.Tweet.InvalidTweetContent);
      }

      var trimmed = rawInput.Trim();

      if (GetGraphemeCount(trimmed) > MaxCharacterCount)
      {
        return Result.Failure<TweetContent>(DomainErrors.Tweet.InvalidTweetContent);
      }

      var hashtags = ExtractMatches(trimmed, HashtagRegex);
      var mentions = ExtractMatches(trimmed, MentionRegex);

      return Result.Success(new TweetContent(trimmed, hashtags, mentions));
    }

    private static List<string> ExtractMatches(string text, Regex regex)
    {
      return regex.Matches(text)
        .Select(m => m.Groups[1].Value)
        .Distinct(StringComparer.OrdinalIgnoreCase)
        .ToList();
    }

    private static int GetGraphemeCount(string text)
    {
      var enumerator = StringInfo.GetTextElementEnumerator(text);
      var count = 0;
      while (enumerator.MoveNext())
      {
        count++;
      }
      return count;
    }

    public static implicit operator string(TweetContent tweetContent) => tweetContent.Value;

    public override string ToString() => Value;
  }
}
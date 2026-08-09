 using System.Globalization;
 
using System.Text.RegularExpressions;
using TwitterClone.Domain.Shared;
 

namespace TwitterClone.Domain.ValueObjects.Message
{
  public sealed record MessageContent
  {
    public const int MaxCharacterCount = 1000;
    
    private static readonly Regex MentionRegex = new(
      @"(?<=^|[\s.,!?:;])@([a-zA-Z0-9_]{3,64})",
      RegexOptions.Compiled | RegexOptions.CultureInvariant
    );

    public string Value { get; }
    public IReadOnlyList<string> Mentions { get; }

    private MessageContent(string value, List<string> mentions)
    {
      Value = value;
      Mentions = mentions.AsReadOnly();
    }

    public static Result<MessageContent> Create(string? rawContent)
    {
      if (string.IsNullOrWhiteSpace(rawContent))
      {
        return Result.Failure<MessageContent>(DomainErrors.Message.InvalidMessageContent);
      }

      var trimmed = rawContent.Trim();

      if (GetGraphemeCount(trimmed) > MaxCharacterCount)
      {
        return Result.Failure<MessageContent>(DomainErrors.Message.InvalidMessageContent);
      }

      var mentions = ExtractMatches(trimmed, MentionRegex);

      return Result.Success(new MessageContent(trimmed, mentions));
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

    public static implicit operator string(MessageContent content) => content.Value;

    public override string ToString() => Value;
  }
}
using System.Text.RegularExpressions;
using TwitterClone.Domain.Shared;


namespace TwitterClone.Domain.ValueObjects.User
{
  public sealed record DisplayName
  {
    public const int MinLength = 1;
    public const int MaxLength = 150;

    private static readonly Regex DisplayNameRegex = new(
      $@"^[\p{{L}} .'\-]{{{MinLength},{MaxLength}}}$",
      RegexOptions.Compiled | RegexOptions.CultureInvariant
    );

    public string Value { get; }

    private DisplayName(string value) => Value = value;

    public static Result<DisplayName> Create(string? rawDisplayName)
    {
      if (string.IsNullOrWhiteSpace(rawDisplayName))
      {
        return Result.Failure<DisplayName>(DomainErrors.User.InvalidDisplayName);
      }

      var trimmed = rawDisplayName.Trim();

      if (!DisplayNameRegex.IsMatch(trimmed))
      {
        return Result.Failure<DisplayName>(DomainErrors.User.InvalidDisplayName);
      }

      return Result.Success(new DisplayName(trimmed));
    }

    public static implicit operator string(DisplayName name) => name.Value;

    public override string ToString() => Value;
  }
}
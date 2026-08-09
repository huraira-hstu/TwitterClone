using System.Text.RegularExpressions;
using TwitterClone.Domain.Shared; 
namespace TwitterClone.Domain.ValueObjects.User
{
  public sealed record Username
  {
    public const int MinLength = 3;
    public const int MaxLength = 64;

    private static readonly Regex UsernameRegex = new(
      $@"^[a-zA-Z0-9_]{{{MinLength},{MaxLength}}}$",
      RegexOptions.Compiled | RegexOptions.CultureInvariant
    );

    public string Value { get; }

    private Username(string value) => Value = value;

    public static Result<Username> Create(string? rawUsername)
    {
      if (string.IsNullOrWhiteSpace(rawUsername))
      {
        return Result.Failure<Username>(DomainErrors.User.InvalidUsername);
      }

      var trimmed = rawUsername.Trim();

      if (!UsernameRegex.IsMatch(trimmed))
      {
        return Result.Failure<Username>(DomainErrors.User.InvalidUsername);
      }

      return Result.Success(new Username(trimmed));
    }

    public static implicit operator string(Username username) => username.Value;

    public override string ToString() => Value;
  }
}
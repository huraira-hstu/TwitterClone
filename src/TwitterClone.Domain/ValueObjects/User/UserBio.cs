using System.Text.RegularExpressions;
using TwitterClone.Domain.Shared;
 
namespace TwitterClone.Domain.ValueObjects.User
{
  public sealed record UserBio
  {
    public const int MaxLength = 300;

    private static readonly Regex BioRegex = new(
      $@"^[\p{{L}}0-9_ .,?!'""\-:;]{{0,{MaxLength}}}$",
      RegexOptions.Compiled | RegexOptions.CultureInvariant
    );

    public string Value { get; }

    private UserBio(string value) => Value = value;

    public static Result<UserBio> Create(string? rawBio)
    {
      if (string.IsNullOrWhiteSpace(rawBio))
      {
        return Result.Success(new UserBio(string.Empty));
      }

      var trimmed = rawBio.Trim();

      if (!BioRegex.IsMatch(trimmed))
      {
        return Result.Failure<UserBio>(DomainErrors.User.InvalidBio);
      }

      return Result.Success(new UserBio(trimmed));
    }

    public static implicit operator string(UserBio bio) => bio.Value;

    public override string ToString() => Value;
  }
}
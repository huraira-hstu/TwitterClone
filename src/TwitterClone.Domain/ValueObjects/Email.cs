using System.Text.RegularExpressions;
using TwitterClone.Domain.Shared;
 

namespace TwitterClone.Domain.ValueObjects.User
{
  public sealed record Email
  {
    public const int MaxLength = 254;

    private static readonly Regex EmailRegex = new(
      @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
      RegexOptions.Compiled | RegexOptions.CultureInvariant
    );

    public string Value { get; }

    private Email(string value) => Value = value;

    public static Result<Email> Create(string? rawEmail)
    {
      if (string.IsNullOrWhiteSpace(rawEmail))
      {
        return Result.Failure<Email>(DomainErrors.Email.InvalidEmailAdress);
      }

      var trimmed = rawEmail.Trim().ToLowerInvariant();

      if (trimmed.Length > MaxLength)
      {
        return Result.Failure<Email>(DomainErrors.Email.InvalidEmailAdress);
      }

      if (!EmailRegex.IsMatch(trimmed))
      {
        return Result.Failure<Email>(DomainErrors.Email.InvalidEmailAdress);
      }

      return Result.Success(new Email(trimmed));
    }

      public static implicit operator string(Email email) => email.Value;

      public override string ToString() => Value;
    }
}
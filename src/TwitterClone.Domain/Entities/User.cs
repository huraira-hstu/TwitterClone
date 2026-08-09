using TwitterClone.Domain.Shared;
using TwitterClone.Domain.ValueObjects;
using TwitterClone.Domain.ValueObjects.User;

namespace TwitterClone.Domain.Entities
{
  public class User : BaseEntity
  {
    public Username Username { get; private set; }
    public DisplayName DisplayName { get; private set; }
    public Email Email { get; private set; }
    public UserBio Bio { get; private set; }   
    public string PasswordHash { get; private set; }
 
    public User(
      Guid id, 
      Username username, 
      DisplayName displayName, 
      Email email, 
      UserBio bio, 
      string passwordHash,
      DateTime createdAt,
      DateTime updatedAt
    ) : base(id, createdAt, updatedAt) {
      Username = username;
      DisplayName = displayName;
      Email = email;
      Bio = bio;
      PasswordHash = passwordHash;
    }

 
        
    public static Result<User> Create(
      string rawUsername, 
      string rawDisplayName, 
      string rawEmail, 
      string rawBio, 
      string passwordHash
    ) {
      var username = Username.Create(rawUsername);
      if (username.IsFailure) return Result.Failure<User>(username.Error);

      var displayName = DisplayName.Create(rawDisplayName);
      if (displayName.IsFailure) return Result.Failure<User>(displayName.Error);

      var email = Email.Create(rawEmail);
      if (email.IsFailure) return Result.Failure<User>(email.Error);

      var bio = UserBio.Create(rawBio);
      if (bio.IsFailure) return Result.Failure<User>(bio.Error);

      return Result.Success(new User(
        Guid.NewGuid(), 
        username.Value, 
        displayName.Value, 
        email.Value, 
        bio.Value, 
        passwordHash,
        DateTime.UtcNow,
        DateTime.UtcNow
      ));
    }

    public Result UpdateBio(string newRawBio)
    {
      var bioResult = UserBio.Create(newRawBio);
      if (bioResult.IsFailure) return Result.Failure(bioResult.Error);

      Bio = bioResult.Value;
      _updated();
      return Result.Success();
    }

    public Result UpdateDisplayName(string newRawDisplayName)
    {
      var displayNameRes = DisplayName.Create(newRawDisplayName);
      if(displayNameRes.IsFailure)return Result.Failure(displayNameRes.Error);

      DisplayName = displayNameRes.Value;
      _updated();
      return Result.Success();
    }
  }
}

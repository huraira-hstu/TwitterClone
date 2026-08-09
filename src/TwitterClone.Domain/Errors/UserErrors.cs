
using TwitterClone.Domain.Shared;

namespace TwitterClone.Domain.DomainErrors;

public static class User{
  public static readonly Error InvalidUsername = new (
    Code: "User.InvalidUserId",
    Description: ""
  ); 

  public static readonly Error InvalidBio = new (
    Code: "User.InvalidBio",
    Description: "Bio cannot exceed 300 characters and can only contain letters, numbers, and puntuations."
  ); 

  public static readonly Error InvalidDisplayName = new (
    Code: "User.InvalidDisplayName",
    Description: ""
  );
}


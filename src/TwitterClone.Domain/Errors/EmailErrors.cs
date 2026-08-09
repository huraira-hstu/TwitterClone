

using TwitterClone.Domain.Shared;
namespace TwitterClone.Domain.DomainErrors;


public static class Email
{
  public static readonly Error InvalidEmailAdress = new (
    Code: "Email.InvalidAddress",
    Description: ""
  );
}
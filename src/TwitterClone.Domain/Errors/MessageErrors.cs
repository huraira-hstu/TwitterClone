
using TwitterClone.Domain.Shared;

namespace TwitterClone.Domain.DomainErrors;


public static class Message
{
  public static readonly Error CannotMessageSelf = new(
    Code: "Message.CannotMessageSelf",
    Description: "You cannot send a direct message to yourself."
  );

  public static readonly Error InvalidMessageContent = new(
    Code: "Message.InvalidContent",
    Description: ""
  );

  public static readonly Error InvalidSender = new(
    Code: "Message.InvalidSender",
    Description: ""
  );
  

  public static readonly Error InvalidReceiver = new(
    Code: "Message.InvalidSender",
    Description: ""
  );
}
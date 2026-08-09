
using TwitterClone.Domain.Shared;

namespace TwitterClone.Domain.DomainErrors;


public static class Notification
{
  public static readonly Error InvalidNotificationContent = new (
    Code: "Notification.InvalidNotificationContent",
    Description: ""
  );

  public static readonly Error InvalidNotificationTitle = new (
    Code: "Notification.InvalidNotificationTitle",
    Description: ""
  );

  public static readonly Error SelfNotificationNotAllowed = new (
    Code: "Notification.SelfNotificationNotAllowed",
    Description: ""
  );

  public static readonly Error InvalidActor = new (
    Code: "Notification.InvalidActor",
    Description: ""    
  );

  public static readonly Error InvalidRecipient = new (
    Code: "Notification.InvalidRecipient",
    Description: ""
  );

  public static readonly Error AlreadyRead = new (
    Code: "Notification.AlreadyRead",
    Description: ""
  );
}
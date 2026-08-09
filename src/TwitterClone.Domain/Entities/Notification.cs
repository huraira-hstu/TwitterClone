using TwitterClone.Domain.Shared;
using TwitterClone.Domain.ValueObjects.Notification;
using TwitterClone.Domain.Enums;

namespace TwitterClone.Domain.Entities
{
  public class Notification : BaseEntity
  {
    public Guid ReceiverId { get; private set; }
    public Guid ActorId { get; private set; }
    public NotificationType Type { get; private set; }
    public NotificationContent Content { get; private set; }
    public Guid? TargetEntityId { get; private set; } 
    public bool IsRead { get; private set; }
    

    public Notification(
      Guid id,
      Guid receiverId,
      Guid actorId,
      NotificationType type,
      NotificationContent content,
      Guid? targetEntityId,
      DateTime createdAt,
      DateTime updatedAt
    ) : base(id, createdAt, updatedAt)
    {
      ReceiverId = receiverId;
      ActorId = actorId;
      Type = type;
      Content = content;
      TargetEntityId = targetEntityId;
      IsRead = false; 
    }
 
    public static Result<Notification> Create(
      Guid receiverId,
      Guid actorId,
      NotificationType type,
      NotificationContent content,
      Guid? targetEntityId = null)
    {
      if (receiverId == Guid.Empty)
      {
        return Result.Failure<Notification>(DomainErrors.Notification.InvalidRecipient);
      }

      if (actorId == Guid.Empty)
      {
        return Result.Failure<Notification>(DomainErrors.Notification.InvalidActor);
      }

     
      if (receiverId == actorId)
      {
        return Result.Failure<Notification>(DomainErrors.Notification.SelfNotificationNotAllowed);
      }

      var notification = new Notification(
        Guid.NewGuid(),
        receiverId,
        actorId,
        type,
        content,
        targetEntityId,
        DateTime.UtcNow,
        DateTime.UtcNow
      );

      return Result.Success(notification);
    }

    public Result MarkAsRead()
    {
      if (IsRead)
      {
        return Result.Failure<Notification>(DomainErrors.Notification.AlreadyRead);
      }
      IsRead = true;
      return Result.Success();
    }
  }
}
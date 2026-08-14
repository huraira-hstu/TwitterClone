namespace TwitterClone.Domain.Entities.Notifications;


public sealed class SystemNotification : Notification
{
  public SystemNotification(
    Guid id, 
    Guid userId, 
    string content,
    DateTime createdAt, 
    Guid createdBy, 
    DateTime? modifiedAt = null, 
    Guid? modifiedBy = null
  ) : base(id, userId, content, "System", createdAt, createdBy, modifiedAt, modifiedBy)
  {
  }

  public void SetNotificationContent(string content)
  {
    Content = content;
  }


}
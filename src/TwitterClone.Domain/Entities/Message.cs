 using TwitterClone.Domain.Shared;
using TwitterClone.Domain.ValueObjects.Message;
 
namespace TwitterClone.Domain.Entities
{
  public class Message : BaseEntity
  {
    public Guid SenderId { get; private set; }
    public Guid ReceiverId { get; private set; }
    public MessageContent Content { get; private set; }
    public bool IsRead { get; private set; }
    public bool IsEdited { get; private set; } = false;
    public DateTime? SeenAt { get; private set; }
 
  
    private Message(
      Guid id,
      Guid senderId,
      Guid receiverId,
      MessageContent content,
      DateTime createdAt,
      DateTime updatedAt  
    )
      : base(id, createdAt, updatedAt)
    {
      SenderId = senderId;
      ReceiverId = receiverId;
      Content = content;
      IsRead = false;
      SeenAt = null;
    }

    public static Result<Message> Create(
      Guid senderId,
      Guid receiverId,
      string rawContent)
    {
      if (senderId == Guid.Empty)
      {
        return Result.Failure<Message>(DomainErrors.Message.InvalidSender);
      }

      if (receiverId == Guid.Empty)
      {
        return Result.Failure<Message>(DomainErrors.Message.InvalidReceiver);
      }

      if (senderId == receiverId)
      {
        return Result.Failure<Message>(DomainErrors.Message.CannotMessageSelf);
      }

      var contentResult = MessageContent.Create(rawContent);
      if (contentResult.IsFailure)
      {
        return Result.Failure<Message>(contentResult.Error);
      }

      var message = new Message(
        Guid.NewGuid(),
        senderId,
        receiverId,
        contentResult.Value,
        DateTime.UtcNow,
        DateTime.UtcNow
      );

      return Result.Success(message);
    }
 

    public void MarkAsRead(DateTime? seenAtUtc = null)
    {
      if (IsRead)
      {
        return;
      }
      IsRead = true;
      SeenAt = seenAtUtc ?? DateTime.UtcNow;
    }

    public Result UpdateContent(string rawContent)
    {
      var contentResult = MessageContent.Create(rawContent);
      if (contentResult.IsFailure)
      {
        return Result.Failure(contentResult.Error);
      }

      this.Content = contentResult.Value;
      this.IsEdited = true;
      _updated();
      return Result.Success();
    }
  }
}
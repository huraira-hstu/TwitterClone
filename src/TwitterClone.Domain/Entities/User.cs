
namespace TwitterClone.Domain.Entities;

public class User : BaseEntity
{
  public string Email {get; private set;}
  public string FullName { get; private set; }
  public string NickName { get; private set; }

  private List<Guid> _followers = new List<Guid>();
  private List<Guid> _incomingNotificatoins = new List<Guid>();


  public User(
    Guid id,
    string email,
    string fullName,
    string nickName,
    DateTime createdAt, 
    Guid createdBy, 
    DateTime? modifiedAt = null, 
    Guid? modifiedBy = null
  ) : base(id, createdAt, createdBy, modifiedAt, modifiedBy)
  {
    Email = email;
    FullName = fullName;
    NickName = nickName;
  }

 
  public void Follow(Guid userId)
  {
    if(!_followers.Contains(userId))
    {
      _followers.Add(userId);
    }
  }

  public void Unfollow(Guid userId)
  {
    _followers.Remove(userId);
  }

  public void AddNotification(Guid notificationId)
  {
    if (!_incomingNotificatoins.Contains(notificationId))
    {
      _incomingNotificatoins.Add(notificationId);
    }
  }

  public override string DescribeRecord()
  {
    return $"""
    {base.DescribeRecord()}
      FullName: {FullName}
      NickName: {NickName}
      Email: {Email}
    """;
  }
}
<<<<<<< HEAD
namespace TwitterClone.Domain.Entities;

public class User : BaseEntity
=======
using TwitterClone.Domain.Entities.Interfaces;

namespace TwitterClone.Domain.Entities;

public class User : BaseEntity, IFollowable, INotifiable
>>>>>>> ea5610e (class-10)
{
  public string Email {get; private set;}
  public string FullName { get; private set; }
  public string NickName { get; private set; }

<<<<<<< HEAD
=======
  private List<Guid> _followers = new List<Guid>();
  private List<Guid> _inComingNotifications = new List<Guid>();

>>>>>>> ea5610e (class-10)

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

<<<<<<< HEAD
    public override string DescribeRecord()
=======
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
    if (!_inComingNotifications.Contains(notificationId))
    {
      _inComingNotifications.Add(notificationId);
    }
  }

  public override string DescribeRecord()
>>>>>>> ea5610e (class-10)
  {
    return $"""
    {base.DescribeRecord()}
      FullName: {FullName}
      NickName: {NickName}
      Email: {Email}
    """;
  }
}
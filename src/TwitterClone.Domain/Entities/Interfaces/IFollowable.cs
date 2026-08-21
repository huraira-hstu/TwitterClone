
namespace TwitterClone.Domain.Entities.Interfaces;


public interface IFollowable
{
  void Follow(Guid userId);
  void Unfollow(Guid userId);
}
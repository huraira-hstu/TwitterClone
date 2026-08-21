namespace TwitterClone.Domain.Entities.Interfaces;


public interface ILikable
{
  bool CanBeLiked();
  public Guid Id { get;}
}
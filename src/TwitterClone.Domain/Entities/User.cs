namespace TwitterClone.Domain.Entities;

public class User : BaseEntity
{
  public string Email {get; private set;}
  public string FullName { get; private set; }
  public string NickName { get; private set; }


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
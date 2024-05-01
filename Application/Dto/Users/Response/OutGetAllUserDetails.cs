namespace Application.Dto.Users.Response;

public sealed class OutGetAllUserDetails
{
  public long Id { get; set; }
  public long SellerId { get; set; }
  public string UserName { get; set; }
  public string? Email { get; set; }
  public string PhoneNumber { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public string[] Roles { get; set; }
  public bool IsActive { get; set; }
  public bool IsProfileComplete { get; set; }
}

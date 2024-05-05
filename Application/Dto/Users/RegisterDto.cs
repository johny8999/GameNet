namespace Application.Dto.Users;

public sealed class RegisterDto
{
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public string NationalCode { get; set; }
  public DateTime? BirthDate { get; set; }
  public DateTime Date { get; set; }
  public string SmsHashCode { get; set; }
  public DateTime? LastTrySentSms { get; set; }
}

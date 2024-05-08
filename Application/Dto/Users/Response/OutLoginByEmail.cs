namespace Application.Dto.Users.Response;

public sealed class OutLoginByEmail
{
  public string Token { get; set; }
  public string RefreshToken { get; set; }
}

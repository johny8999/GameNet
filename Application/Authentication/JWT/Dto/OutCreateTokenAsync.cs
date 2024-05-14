namespace Application.Authentication.JWT.Dto;

public sealed class OutCreateTokenAsync
{
  public string Token { get; set; }
  public string UserId { get; set; }
}

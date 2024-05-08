using System.ComponentModel.DataAnnotations;
using FrameWork.DataAnnotations.String;

namespace Application.Authentication.JWT.Dto;

public sealed class CreateTokenDto
{
  [RequiredString]
  [EmailAddress]
  public string UserEmail { get; set; }

  public string Password { get; set; }
}

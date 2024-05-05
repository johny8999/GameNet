using System.ComponentModel.DataAnnotations;
using FrameWork.DataAnnotations.String;

namespace Application.Dto.Users.Request;

public sealed class LoginByEmailPasswordDto
{
  [Display(Name = "شناسه")]
  [RequiredString]
  public string Email { get; set; }
  [Display(Name = "ؤمز عبور")]
  [RequiredString]
  public long Password { get; set; }

}

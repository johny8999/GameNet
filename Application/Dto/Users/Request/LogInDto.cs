using System.ComponentModel.DataAnnotations;
using FrameWork.DataAnnotations.String;

namespace Application.Dto.Users.Request;

public sealed class LogInDto
{
  [Display(Name = "شناسه")]
  [RequiredString]
  public long UserId { get; set; }
  [Display(Name = "ؤمز عبور")]
  [RequiredString]
  public long Password { get; set; }

}

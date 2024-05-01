using System.ComponentModel.DataAnnotations;
using FrameWork.DataAnnotations.String;

namespace Application.Dto.Users.Request;

public sealed class InpGetAllUserDetails
{
  [Display(Name = "شناسه")]
  [RequiredString]
  public long UserId { get; set; }
}

using System.ComponentModel.DataAnnotations;
using FrameWork.DataAnnotations.String;

namespace Application.Dto.UserRole.Request;

public record ChangeRoleDto()
{
  [Display(Name = "شناسه کاربر")]
  [RequiredString]
  [GUID]
  public string UserId { get; set; }

  [Display(Name = "شناسه نقش")]
  [RequiredString]
  [GUID]
  public string OldRoleId { get; set; }

  [Display(Name = "شناسه نقش")]
  [RequiredString]
  [GUID]
  public string NewRoleId { get; set; }
}

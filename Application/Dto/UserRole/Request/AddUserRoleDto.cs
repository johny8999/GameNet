using System.ComponentModel.DataAnnotations;
using FrameWork.DataAnnotations.String;

namespace Application.Dto.UserRole.Request;

public record AddUserRoleDto
{
  [Display(Name = "شناسه کاربر")]
  [RequiredString]
  [GUID]
  public string UserId { get; set; }

  [Display(Name = "شناسه نقش")]
  [RequiredString]
  [GUID]
  public string RoleId { get; set; }
}

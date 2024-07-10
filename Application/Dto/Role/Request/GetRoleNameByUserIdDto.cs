using System.ComponentModel.DataAnnotations;
using FrameWork.DataAnnotations.String;

namespace Application.Dto.Role.Request;

public sealed class GetRoleNameByUserIdDto
{
  [Display(Name = "شناسه کاربر")]
  [RequiredString]
  [GUID]
  public string UserId { get; set; }
}

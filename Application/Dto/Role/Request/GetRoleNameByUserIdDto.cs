using FrameWork.DataAnnotations.String;

namespace Application.Dto.Role.Request;

public sealed class GetRoleNameByUserIdDto
{
  [RequiredString]
  [GUID]
  public string UserId { get; set; }
}

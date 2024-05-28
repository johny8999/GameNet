using FrameWork.DataAnnotations.String;

namespace Application.Authentication.JWT.Dto;

public sealed class SaveTokenDto
{
  [RequiredString] [GUID] public string UserId { get; set; }
  [RequiredString] public string Token { get; set; }
}

using System.ComponentModel.DataAnnotations;
using FrameWork.DataAnnotations.String;

namespace Application.Dto.SubEntity;

public sealed class AddTimeToEntityDto
{
  [Display(Name = "گروه")]
  [RequiredString]
  [GUID]
  public string UserId { get; set; }
  [Display(Name = "گروه")]
  [RequiredString]
  [GUID]
  public string GameNetId { get; set; }

  [Display(Name = "گروه")]
  [RequiredString]
  [GUID]
  public string SubEntityId { get; set; }
}

using System.ComponentModel.DataAnnotations;
using FrameWork.DataAnnotations.String;

namespace Application.Dto.SubEntity;

public sealed class AddSubEntityByGameNetAndEntityDto
{
  [Display(Name = "نام ")]
  [RequiredString]
  public string Name { get; set; }

  [Display(Name = "گروه")]
  [RequiredString]
  [GUID]
  public string EntityId { get; set; }

  [Display(Name = "گیم نت")]
  [RequiredString]
  [GUID]
  public string GameNetId { get; set; }


}

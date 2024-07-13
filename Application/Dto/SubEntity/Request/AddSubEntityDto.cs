using System.ComponentModel.DataAnnotations;
using FrameWork.DataAnnotations.String;

namespace Application.Dto.SubEntity.Request;

public record AddSubEntityDto
{
  [Display(Name = "نام ")]
  [RequiredString]
  public string Name { get; set; }

  [Display(Name = "شناسه موجودیت")]
  [RequiredString]
  [GUID]
  public string EntityId { get; set; }
}

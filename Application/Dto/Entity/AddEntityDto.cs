using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FrameWork.DataAnnotations.String;

namespace Application.Dto.Entity;

public sealed class AddEntityDto
{
  [Display(Name = "نام ")]
  [RequiredString]
  public string EntityName { get; set; }
}

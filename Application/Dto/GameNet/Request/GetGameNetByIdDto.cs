using System.ComponentModel.DataAnnotations;
using FrameWork.DataAnnotations.String;

namespace Application.Dto.GameNet.Request;

public  record GetGameNetByIdDto
{
  [Display(Name = "شناسه")]
  [RequiredString]
  public string Id { get; set; }
}

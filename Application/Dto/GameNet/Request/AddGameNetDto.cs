using System.ComponentModel.DataAnnotations;
using FrameWork.DataAnnotations.String;

namespace Application.Dto.GameNet.Request;

public sealed class AddGameNetDto
{
  [Display(Name = "نام")]
  [RequiredString]
  public string Name { get; set; }

  [Display(Name = "شناسه شهر")]
  [RequiredString]
  [GUID]
  public string CityId { get; set; }
}

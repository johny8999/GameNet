using System.ComponentModel.DataAnnotations;
using FrameWork.DataAnnotations.String;
using Newtonsoft.Json;

namespace Application.Dto.CustomerAccounting.Request;

public sealed class AddCustomerAccountByTimeDto
{
  [Display(Name = "کاربر")]
  [RequiredString]
  [GUID]
  public string UserId { get; set; }

  [Display(Name = "زمان خرید")]
  [Required]
  public short PurchaseTime { get; set; }

  [Display(Name = "'گیم نت")]
  [RequiredString]
  [GUID]
  public string SubEntityGameNetId { get; set; }
}

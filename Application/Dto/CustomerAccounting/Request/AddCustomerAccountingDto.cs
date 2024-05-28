using System.ComponentModel.DataAnnotations;
using FrameWork.DataAnnotations.String;
using Newtonsoft.Json;

namespace Application.Dto.CustomerAccounting.Request;

public sealed class AddCustomerAccountingDto
{

  [Display(Name = "کاربر")]
  [RequiredString]
  [GUID]
  public string UserId { get; set; }

  [Display(Name = "مبلغ خرید")]
  [Required]
  public decimal Purchase { get; set; }

  [JsonIgnore] public DateTime PurchaseDate { get; set; } = DateTime.Now;

  [Display(Name = "'گیم نت")]
  [RequiredString]
  [GUID]
  public string SubEntityGameNetId { get; set; }
}

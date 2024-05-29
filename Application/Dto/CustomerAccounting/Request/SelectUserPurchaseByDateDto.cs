using System.ComponentModel.DataAnnotations;
using FrameWork.DataAnnotations.String;

namespace Application.Dto.CustomerAccounting.Request;

public record SelectUserPurchaseByDateDto
{
  [Display(Name = "کاربر")]
  [RequiredString]
  [GUID]
  public string UserId { get; set; }

  [Display(Name = "زمان خرید")]
  [Required]
  public DateTime PurchaseDate { get; set; }
}

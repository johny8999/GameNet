using System.ComponentModel.DataAnnotations;
using FrameWork.DataAnnotations.Numbers.All;

namespace Application.Dto.PalletOperation.Request;

public sealed class GetPalletOperationByInputCountRequestDto
{
    [Display(Name = "تعداد دریافتی")]
    [Required]
    [NumRange(1,20)]
    public short Take { get; set; }
}
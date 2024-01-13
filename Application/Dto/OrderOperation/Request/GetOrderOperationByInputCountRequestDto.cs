using System.ComponentModel.DataAnnotations;
using FrameWork.DataAnnotations.Numbers.All;

namespace Application.Dto.OrderOperation.Request;

public sealed class GetOrderOperationByInputCountRequestDto
{
    [Display(Name = "تعداد دریافتی")]
    [Required]
    [NumRange(1,20)]
    public short Take { get; set; }
}
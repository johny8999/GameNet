using System.ComponentModel.DataAnnotations;
using FrameWork.DataAnnotations.Numbers.All;

namespace Application.Dto.UserOperation.Request;

public sealed class GetUserOperationByInputRequestDto
{
    [Display(Name = "تعداد دریافتی")]
    [Required]
    [NumRange(1, 20)]
    public short Take { get; set; }
}
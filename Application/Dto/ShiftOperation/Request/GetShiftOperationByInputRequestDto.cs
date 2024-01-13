using System.ComponentModel.DataAnnotations;
using FrameWork.DataAnnotations.Numbers.All;

namespace Application.Dto.ShiftOperation.Request;

public sealed class GetShiftOperationByInputRequestDto
{
    [Display(Name = "تعداد دریافتی")]
    [Required]
    [NumRange(1, 20)]
    public short Take { get; set; }
}
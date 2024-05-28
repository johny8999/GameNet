using System.ComponentModel.DataAnnotations;
using FrameWork.ExMethods;

namespace FrameWork.DataAnnotations.String;

public class AlphabetAttribute : ValidationAttribute
{
  public AlphabetAttribute()
  {
    ErrorMessage ??= "AlphabetMsg";
  }

  protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
  {
    if (value is null)
      return ValidationResult.Success;

    if (value is not string)
      return ValidationResult.Success;

    var stringOut = StringEx.RemoveWhiteSpace(value.ToString()!);
    if (stringOut!.Length == 0)
    {
      ErrorMessage = "lenght must be upper than 0 ";
      return new ValidationResult(ErrorMessage!.Replace("{0}", validationContext.DisplayName));
    }


    if (StringEx.IsMatch(stringOut, "^[^\"!@#%\\^\\$&\\*\\+=~`\\[\\]\\{\\}\\|;:<>\\?\\/\\\\]+$"))
      return ValidationResult.Success;
    else
      return new ValidationResult(ErrorMessage!.Replace("{0}", validationContext.DisplayName));
  }
}

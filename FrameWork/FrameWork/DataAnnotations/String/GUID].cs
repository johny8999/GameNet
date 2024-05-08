using System.ComponentModel.DataAnnotations;

namespace FrameWork.DataAnnotations.String;

public class GUIDAttribute : ValidationAttribute
{
  protected override ValidationResult IsValid(object value, ValidationContext validationContext)
  {
    try
    {
      if (value is null)
        return ValidationResult.Success;

      if (value is not string)
        return ValidationResult.Success;

      if (value.ToString().Contains(','))
      {
        foreach (var item in value.ToString().Split(','))
        {
          if (!string.IsNullOrEmpty(item))
          {
            var _Guid = Guid.Parse(item);
          }
        }

        return ValidationResult.Success;
      }
      else
      {
        #region Way1

        // Guid guid = default;
        //var IsGuid = Guid.TryParse((string)value,out guid);

        #endregion Way1

        var _Guid = Guid.Parse((string)value);
        return ValidationResult.Success;
      }
    }
    catch (Exception)
    {
      return new ValidationResult(GetMessage(validationContext));
    }
  }

  public string? GetMessage(ValidationContext validationContext)
  {
    if (ErrorMessage != null && ErrorMessage.Contains("{0}"))
      ErrorMessage = ErrorMessage.Replace("{0}", validationContext.DisplayName);

    return ErrorMessage;
  }
}

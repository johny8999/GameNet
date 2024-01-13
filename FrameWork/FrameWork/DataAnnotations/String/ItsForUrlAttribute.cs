using System.ComponentModel.DataAnnotations;
using FrameWork.ExMethods;

namespace FrameWork.DataAnnotations.String
{
    public class ItsForUrlAttribute : ValidationAttribute
    {
        public ItsForUrlAttribute()
        {
            if (ErrorMessage == null)
                ErrorMessage = "<span class='da-text'>{0} حاوی کاراکترهای غیرمجاز میباشد. کاراکترهای مجاز:</span><ul class='da-list'><li>حروف و اعداد انگلیسی</li><li>کاراکتر خط تیره (-)</li></ul>";
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null)
                return ValidationResult.Success;

            if (value is not string)
                throw new Exception("Value only can be string.");

            if (((string)value).IsMatch(@"^[a-zA-Z0-9\-]*$"))
                return ValidationResult.Success;
            else
                return new ValidationResult(GetMessage(validationContext));
        }

        public string GetMessage(ValidationContext validationContext)
        {
            if (ErrorMessage.Contains("{0}"))
                ErrorMessage = ErrorMessage.Replace("{0}", validationContext.DisplayName);

            return ErrorMessage;
        }
    }
}


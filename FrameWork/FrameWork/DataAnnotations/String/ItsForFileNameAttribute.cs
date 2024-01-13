using System.ComponentModel.DataAnnotations;
using FrameWork.ExMethods;

namespace FrameWork.DataAnnotations.String
{
    public class ItsForFileNameAttribute : ValidationAttribute
    {
        public ItsForFileNameAttribute()
        {
            if (ErrorMessage == null)
                ErrorMessage = "<span class='da-text'>{0} حاوی کاراکترهای غیرمجاز میباشد. کاراکترهای مجاز:</span><ul class='da-list'><li>حروف و اعداد انگلیسی</li><li>کاراکتر خط تیره (-)</li>i>کاراکتر خط فاصله ( )</li>i>کاراکتر Underline (_)</li>i>کاراکتر پرانتز ()</li></ul>";
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null)
                return ValidationResult.Success;

            if (value is not string)
                throw new Exception("Value only can be string.");

            if (((string)value).IsMatch(@"\A(?!(?:COM[0-9]|CON|LPT[0-9]|NUL|PRN|AUX|com[0-9]|con|lpt[0-9]|nul|prn|aux)|\s|[\.]{2,})[^\\\/:*""?<>|]{1,254}(?<![\s\.])\z"))
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


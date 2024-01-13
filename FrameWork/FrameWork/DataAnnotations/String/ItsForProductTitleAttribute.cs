using System.ComponentModel.DataAnnotations;
using FrameWork.ExMethods;

namespace FrameWork.DataAnnotations.String
{
    public class ItsForProductTitleAttribute : ValidationAttribute
    {
        public ItsForProductTitleAttribute()
        {
            if (ErrorMessage == null)
                ErrorMessage = "<span class='da-text'>{0} حاوی کاراکترهای غیرمجاز میباشد. کاراکترهای مجاز:</span><ul class='da-list'><li>حروف و اعداد انگلیسی و فارسی و عربی</li><li>کاراکترهای )(*-.،,_«»</li></ul>";
        }
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null)
                return ValidationResult.Success;

            if (value is not string)
                throw new Exception("مقدار فقط میتواند رشته باشد");


            if (((string)value).IsMatch("^[a-zا-یA-Z،,آ0-9\\-\\.\\)\\(\\+\\s_ءئأإؤيةًٌٍَُِّۀ»«]*$"))
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

using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace FrameWork.DataAnnotations.String
{
    public class DateAttribute : ValidationAttribute
    {
        public DateAttribute()
        {
            if (ErrorMessage == null)
                ErrorMessage = "قالب '{0}' اشتباه است. قالب صحیح: xxxx/xx/xx";
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            if (value is not string)
                return ValidationResult.Success;

            string dateRegex = "[1][3-4][0-9][0-9][\\/\\-]([0][1-9])|([1][0-2])[\\/\\-]([0][1-9])|([1-2][0-9])|([3][0-1])";

            if (!Regex.IsMatch((string)value, dateRegex))
                ErrorMessage = ErrorMessage.Replace("{0}", validationContext.DisplayName);

            return ValidationResult.Success;
        }
    }
}

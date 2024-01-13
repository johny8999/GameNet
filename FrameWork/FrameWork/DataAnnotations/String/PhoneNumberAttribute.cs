using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace FrameWork.DataAnnotations.String
{
    public class PhoneNumberAttribute : ValidationAttribute
    {
        public PhoneNumberAttribute()
        {
            if (ErrorMessage == null)
                ErrorMessage = "قالب '{0}' اشتباه است. قالب صحیح: 09xxxxxxxxx";
        }
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            if (value is not string)
                return ValidationResult.Success;

            string phoneNumberRegex = "^[0][9][0-9]{9}$";

            if (!Regex.IsMatch((string)value, phoneNumberRegex))
                return new ValidationResult(ErrorMessage.Replace("{0}", validationContext.DisplayName));

            return ValidationResult.Success;
        }
    }
}

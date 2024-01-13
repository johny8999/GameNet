using System.ComponentModel.DataAnnotations;

namespace FrameWork.DataAnnotations.Numbers.All
{
    public class ItsIntegerNumberAttribute : ValidationAttribute
    {
        public long Min { get; set; }
        public long Max { get; set; }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            try
            {
                if (ErrorMessage == null)
                    ErrorMessage = "{0} باید عددی بین {1} تا {2} باشد.";

                if (value is null)
                    return ValidationResult.Success;

                if (value is not string)
                    throw new Exception("ItsIntegerNumber فقط میتواند روی نوع رشته کار کند");

                if (long.Parse((string)value) < Min || long.Parse((string)value) > Max)
                    return new ValidationResult(GetMessage(validationContext));
                else
                    return ValidationResult.Success;
            }
            catch (Exception)
            {
                return new ValidationResult(GetMessage(validationContext));
            }
        }

        public string GetMessage(ValidationContext validationContext)
        {
            if (ErrorMessage.Contains("{0}"))
                ErrorMessage = ErrorMessage.Replace("{0}", validationContext.DisplayName);

            if (ErrorMessage.Contains("{1}"))
                ErrorMessage = ErrorMessage.Replace("{1}", Min.ToString())
                                           .Replace("{2}", Max.ToString());

            return ErrorMessage;
        }
    }
}

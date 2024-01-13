using System.ComponentModel.DataAnnotations;

namespace FrameWork.DataAnnotations.String
{
    public class MaxLengthStringAttribute : ValidationAttribute
    {
        private readonly int _max;
        public MaxLengthStringAttribute(int max)
        {
            if (ErrorMessage == null)
                ErrorMessage = "تعداد کاراکترهای '{0}' بیش از حد مجاز ({1} کاراکتر) میباشد.";

            _max = max;
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null)
                return ValidationResult.Success;

            if (value is not string)
                throw new Exception("Value only can be string.");

            if (value.ToString().Length > _max)
                return new ValidationResult(GetMessage(validationContext));

            return ValidationResult.Success;
        }

        public string GetMessage(ValidationContext validationContext)
        {
            if (ErrorMessage.Contains("{0}"))
                ErrorMessage = ErrorMessage.Replace("{0}", validationContext.DisplayName);

            if (ErrorMessage.Contains("{1}"))
                ErrorMessage = ErrorMessage.Replace("{1}", _max.ToString());

            return ErrorMessage;
        }
    }
}

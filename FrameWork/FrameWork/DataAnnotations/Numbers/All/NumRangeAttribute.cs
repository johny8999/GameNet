using System.ComponentModel.DataAnnotations;

namespace FrameWork.DataAnnotations.Numbers.All
{
    public class NumRangeAttribute : ValidationAttribute
    {
        private readonly decimal _min;
        private readonly decimal _max;
        public NumRangeAttribute(decimal min, decimal max)
        {
            _min = min;
            _max = max;
        }

        public NumRangeAttribute(int min, int max)
        {
            _min = min;
            _max = max;
        }

        public NumRangeAttribute(long min, long max)
        {
            _min = min;
            _max = max;
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (ErrorMessage == null)
                ErrorMessage = "{0} باید عددی بین {1} تا {2} باشد.";

            if (value is null)
                return ValidationResult.Success;

            if (value is not int
                && value is not byte
                && value is not short
                && value is not long
                && value is not sbyte
                && value is not ushort
                && value is not uint
                && value is not ulong
                && value is not float
                && value is not double
                && value is not decimal)
                throw new Exception("مقدار (NumRangeAttribute) باید عدد باشد");

            if (Convert.ToDecimal(value) < _min || Convert.ToDecimal(value) > _max)
                return new ValidationResult(GetMessage(validationContext));
            else
                return ValidationResult.Success;
        }

        public string GetMessage(ValidationContext validationContext)
        {
            if (ErrorMessage.Contains("{0}"))
                ErrorMessage = ErrorMessage.Replace("{0}", validationContext.DisplayName);

            if (ErrorMessage.Contains("{1}"))
                ErrorMessage = ErrorMessage.Replace("{1}", _min.ToString())
                                           .Replace("{2}", _max.ToString());

            return ErrorMessage;
        }
    }
}

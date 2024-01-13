using System.ComponentModel.DataAnnotations;

namespace FrameWork.DataAnnotations.String
{
    public class GuidAttribute : ValidationAttribute
    {
        public GuidAttribute()
        {
            if (ErrorMessage == null)
                ErrorMessage = "{0} باید از نوع GUID باشد.";
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                if (value is null)
                    return ValidationResult.Success;

                if (value is not string)
                    throw new Exception("مقدار فقط میتواند رشته باشد");

                if (string.IsNullOrEmpty((string)value) || string.IsNullOrWhiteSpace((string)value))
                    return ValidationResult.Success;

                Guid guid = Guid.Empty;
                if (value.ToString().Contains(","))
                {
                    foreach (var item in value.ToString().Split(","))
                        if (string.IsNullOrEmpty(item) == false)
                            guid = Guid.Parse(item);
                }
                else
                    guid = Guid.Parse((string)value);

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

            return ErrorMessage;
        }
    }
}

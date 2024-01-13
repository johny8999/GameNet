using System.ComponentModel.DataAnnotations;

namespace FrameWork.DataAnnotations.String
{
    public class RequiredForDraftAttribute : ValidationAttribute
    {
        public RequiredForDraftAttribute()
        {
            if (ErrorMessage == null)
                ErrorMessage = "وارد کردن '{0}' الزامی است.";
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            var isDraft = (bool?)validationContext.ObjectInstance.GetType().GetProperty("IsDraft").GetValue(validationContext.ObjectInstance);
            if (isDraft == null)
                isDraft = false;

            if (isDraft.Value == false)
                if (value == null)
                    return new ValidationResult(GetMessage(validationContext));

            return ValidationResult.Success;
        }

        public string GetMessage(ValidationContext validationContext)
        {
            if (ErrorMessage.Contains("{0}"))
                ErrorMessage = ErrorMessage.Replace("{0}", validationContext.DisplayName);

            return ErrorMessage;
        }
    }
}

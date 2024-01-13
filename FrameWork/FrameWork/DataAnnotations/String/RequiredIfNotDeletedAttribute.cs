using System.ComponentModel.DataAnnotations;

namespace FrameWork.DataAnnotations.String
{
    public class RequiredIfNotDeletedAttribute : ValidationAttribute
    {
        public RequiredIfNotDeletedAttribute()
        {
            if (ErrorMessage == null)
                ErrorMessage = "وارد کردن '{0}' الزامی است.";
        }
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            var isDelete = (bool?)validationContext.ObjectInstance.GetType().GetProperty("IsDelete").GetValue(validationContext.ObjectInstance);
            if (isDelete == null)
                isDelete = false;

            if (isDelete.Value == false)
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

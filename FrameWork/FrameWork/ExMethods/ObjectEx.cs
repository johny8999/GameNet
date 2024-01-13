using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using FrameWork.Exceptions;

namespace FrameWork.ExMethods
{
    public static class ObjectEx
    {
        private static List<ValidationResult> Check<T>(T input, IServiceProvider serviceProvider, string? sectionName = "")
        {
            if (input is null)
                throw new ArgumentInvalidException($"{nameof(input)} cant be null.");

            var validationResult = new List<ValidationResult>();

            foreach (var item in input.GetType().GetProperties())
            {
                if (item.PropertyType.GetInterfaces().Contains(typeof(IList)))
                {
                    var lstVals = (IEnumerable)item.GetValue(input)!;
                    if (lstVals!=null)
                        foreach (var itemLst in lstVals)
                            validationResult.AddRange(Check(itemLst, serviceProvider, GetName(item)));
                }
            }

            var validationContext = new ValidationContext(input);
            validationContext.InitializeServiceProvider(t => serviceProvider);

            Validator.TryValidateObject(input, validationContext, validationResult, true);

            return validationResult.Select(a => new ValidationResult(sectionName+ a.ErrorMessage, a.MemberNames)).ToList();
        }

        private static string? GetName(PropertyInfo input)
        {
            object? attr = input.GetCustomAttributes(true).FirstOrDefault(a => a.GetType().Name=="DisplayAttribute");
            if (attr==null)
                return "";

            return (string)attr.GetType().GetProperty("Name")?.GetValue(attr)!;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <param name="serviceProvider"></param>
        /// <exception cref="ArgumentInvalidException">When modelstate error.</exception>
        public static void CheckModelState<T>(this T input, IServiceProvider serviceProvider) where T : class
        {
            var errors = Check(input, serviceProvider);
            if (errors.Any())
                throw new ArgumentInvalidException(string.Join(",", errors.Select(a => a.ErrorMessage)));
        }

        public static string GetModelStateErrors<T>(this T input, IServiceProvider serviceProvider) where T : class
        {
            var errors = Check(input, serviceProvider);

            if (!errors.Any())
                return null;

            return string.Join(",", errors.Select(a => a.ErrorMessage));
        }

    }
}

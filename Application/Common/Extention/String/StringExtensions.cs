using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Application.Common.Extention.String
{
    public static class StringExtensions
    {
        private static JsonSerializerOptions options = new()
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            PropertyNameCaseInsensitive = true,

            WriteIndented = true
        };

        /// <summary>
        /// Serialize Object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Serialize(this object obj)
        {
            return JsonSerializer.Serialize(obj, options);
        }

        /// <summary>
        /// Deserialize Object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T Deserialize<T>(this string? obj)
        {
            if (string.IsNullOrEmpty(obj))
                return default !;
            return JsonSerializer.Deserialize<T>(obj, options)!;
        }


        public static Guid ToGuid(this string input)
        {
            return Guid.Parse(input);
        }

        public static bool IsMatch(this string input, string pattern, RegexOptions regexOptions = default)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException($"'{nameof(input)}' cannot be null or empty.", nameof(input));

            if (string.IsNullOrEmpty(pattern))
                throw new ArgumentException($"'{nameof(pattern)}' cannot be null or empty.", nameof(pattern));

            return Regex.IsMatch(input, pattern, regexOptions);
        }

        public static string? GetDisplayName(this Enum enumValue)
        {
            return CustomAttributeExtensions.GetCustomAttribute<DisplayAttribute>(Enumerable.First(enumValue.GetType()
                        .GetMember(enumValue.ToString())))
                ?.GetName();
        }

        public static string RemoveWhiteSpace(this string input)
        {
            string result = null!;
            var inputSplit = input.Split(" ");
            foreach (var item in inputSplit)
                result += item;

            return result;
        }

        public static string ToEnglishNumber(this string str)
        {
            return str.Replace("۰", "0")
                .Replace("۱", "1")
                .Replace("۲", "2")
                .Replace("۳", "3")
                .Replace("۴", "4")
                .Replace("۵", "5")
                .Replace("۶", "6")
                .Replace("۷", "7")
                .Replace("۸", "8")
                .Replace("۹", "9")
                //iphone numeric
                .Replace("٠", "0")
                .Replace("١", "1")
                .Replace("٢", "2")
                .Replace("٣", "3")
                .Replace("٤", "4")
                .Replace("٥", "5")
                .Replace("٦", "6")
                .Replace("٧", "7")
                .Replace("٨", "8")
                .Replace("٩", "9");
        }

        public static string ToFarsiNumber(this string str)
        {
            return str.Replace("0", "۰")
                .Replace("1", "۱")
                .Replace("2", "۲")
                .Replace("3", "۳")
                .Replace("4", "۴")
                .Replace("5", "۵")
                .Replace("6", "۶")
                .Replace("7", "۷")
                .Replace("8", "۸")
                .Replace("9", "۹")
                //iphone numeric
                .Replace("0", "٠")
                .Replace("1", "۱")
                .Replace("2", "۲")
                .Replace("3", "۳")
                .Replace("4", "۴")
                .Replace("5", "۵")
                .Replace("6", "۶")
                .Replace("7", "۷")
                .Replace("8", "۸")
                .Replace("9", "۹");
        }

        public static string FixPersianChars(this string str)
        {
            return str.Replace("ﮎ", "ک")
                .Replace("ﮏ", "ک")
                .Replace("ﮐ", "ک")
                .Replace("ﮑ", "ک")
                .Replace("ك", "ک")
                .Replace("ي", "ی")
                .Replace(" ", " ")
                .Replace("‌", " ")
                .Replace("ھ", "ه");
        }
    }
}

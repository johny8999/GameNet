using System.IO.Compression;
using System.Text;
using System.Text.RegularExpressions;
using NETCore.Encrypt;

namespace FrameWork.ExMethods
{
    public static class StringEx
    {
        public static string AesEncrypt(this string text, string key)
        {
            if (string.IsNullOrEmpty(key) || string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException("Key Cannot be null.");

            string encrypt = EncryptProvider.AESEncrypt(text, key);

            return encrypt;
        }

        public static string AesDecrypt(this string text, string key)
        {
            if (string.IsNullOrEmpty(key) || string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException("Key Cannot be null.");

            string decrypt = EncryptProvider.AESDecrypt(text, key);

            return decrypt;
        }

        public static Guid ToGuid(this string text)
        {
            return Guid.Parse(text);
        }

        public static string ToMd5(this string text)
        {
            string md5Hash = EncryptProvider.Md5(text);
            return md5Hash;
        }

        public static string ReplaceRegex(this string text, string pattern, string newText)
        {
            string replaceTxt = Regex.Replace(text, pattern, newText, RegexOptions.Multiline | RegexOptions.Singleline);
            return replaceTxt;
        }

        public static bool IsMatch(this string text, string pattern, RegexOptions regexOptions = default)
        {
            return Regex.IsMatch(text, pattern, regexOptions);
        }

        public static string RemoveAllHtmlTags(this string str)
        {
            string text = str.ReplaceRegex("<.*?>", "");
            return text;
        }

        public static string ToLowerCaseForUrl(this string urlName)
        {
            string newStr = "";

            foreach (var item in urlName)
            {
                if (Regex.IsMatch(item.ToString(), "^[A-Z]*$"))
                    newStr += "-" + item.ToString().ToLower();
                else
                    newStr += item.ToString();
            }

            return newStr.Trim('-').Replace("--", "-");
        }

        public static string ToNormalizedUrl(this string str)
        {
            foreach (var item in str)
            {
                if (Regex.IsMatch(item.ToString(), @"^[A-Zا-یa-zئءأإؤيةَُِّۀًٌٍلآ\-\.]*$") == false)
                    str = str.Replace(item, '-');
            }

            return str.Trim('-').Replace("--", "-");
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

        public static double GetValidPrice(this string str)
        {
            str = str.ToEnglishNumber();

            string validPrice = "";

            foreach (var item in str.ToCharArray())
            {
                if (item.ToString().IsMatch(@"^[0-9\.\/]$"))
                    validPrice += item;
            }

            return double.Parse(validPrice);
        }

        public static string Compress(this string uncompressedString)
        {
            byte[] compressedBytes;

            using (var uncompressedStream = new MemoryStream(Encoding.UTF8.GetBytes(uncompressedString)))
            {
                using (var compressedStream = new MemoryStream())
                {
                    // setting the leaveOpen parameter to true to ensure that compressedStream will not be closed when compressorStream is disposed
                    // this allows compressorStream to close and flush its buffers to compressedStream and guarantees that compressedStream.ToArray() can be called afterward
                    // although MSDN documentation states that ToArray() can be called on a closed MemoryStream, I don't want to rely on that very odd behavior should it ever change
                    using (var compressorStream = new DeflateStream(compressedStream, CompressionLevel.Fastest, true))
                    {
                        uncompressedStream.CopyTo(compressorStream);
                    }

                    // call compressedStream.ToArray() after the enclosing DeflateStream has closed and flushed its buffer to compressedStream
                    compressedBytes = compressedStream.ToArray();
                }
            }

            return Convert.ToBase64String(compressedBytes);
        }

        public static string Decompress(this string compressedString)
        {
            byte[] decompressedBytes;

            var compressedStream = new MemoryStream(Convert.FromBase64String(compressedString));

            using (var decompressorStream = new DeflateStream(compressedStream, CompressionMode.Decompress))
            {
                using (var decompressedStream = new MemoryStream())
                {
                    decompressorStream.CopyTo(decompressedStream);

                    decompressedBytes = decompressedStream.ToArray();
                }
            }

            return Encoding.UTF8.GetString(decompressedBytes);
        }
    }
}
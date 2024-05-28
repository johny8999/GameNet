using System.ComponentModel.DataAnnotations;
using System.IO.Compression;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using NETCore.Encrypt;

namespace FrameWork.ExMethods
{
  public static class StringEx
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

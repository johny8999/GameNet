using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace FrameWork.Utility;

public static class StaticData
{
  public static JsonSerializerOptions CacheJsonOptions = new JsonSerializerOptions
  {
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    WriteIndented = true
  };

  #region properties

  public static string ToJson(object data)
  {
    try
    {
      return JsonSerializer.Serialize(data, CacheJsonOptions);
    }
    catch (Exception)
    {
      return "NOErrorConvertObjectToJson";
    }
  }

  public static string? AllSqlCon { get; set; }
  public static string? LogServerName { get; set; }
  public static bool? IsDevelopment { get; set; } = false;
  public static bool? IsRequiredFeedback { get; set; } = true;
  public static int ServicePort { get; set; }
  public static string Version { get; set; } = "0.9.4.0";

  #endregion properties


  public static void Config(IConfiguration config)
  {
    ServicePort = 6585;
    var currentConfig = config.GetSection("Environment").Value?.Trim().ToUpper();
    switch (currentConfig)
    {
      case "TEST":
        AllSqlCon = "Server=.;Database=GameNet;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;";
        LogServerName =
          "Server=.;Database=GameNetLog;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;";
        IsDevelopment = true;
        IsRequiredFeedback = true;
        break;
      case "RELEASE":
        AllSqlCon =
          // "Server=sa;Database=DataAcquisitionOEE;User Id=sa;Password=12345678";
          "Server=DESKTOP-8852LTQ;Database=GameNet;Trusted_Connection=False;TrustServerCertificate=True;Encrypt=False;";
        LogServerName = "IOTReminderServer";
        IsDevelopment = false;
        IsRequiredFeedback = true;
        break;
      case "Server":
        AllSqlCon =
          // "Server=sa;Database=DataAcquisitionOEE;User Id=sa;Password=12345678";
          "Server=DESKTOP-8852LTQ;Database=GameNet;Trusted_Connection=False;TrustServerCertificate=True;Encrypt=False;";
        LogServerName = "IOTReminderServer";
        IsDevelopment = true;
        IsRequiredFeedback = false;
        break;
    }
  }
}

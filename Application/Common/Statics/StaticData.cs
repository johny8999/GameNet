using System.Net;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace Application.Common.Statics;

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

  public static string? LogServer { get; set; }
  public static string? AllSqlCon { get; set; }
  public static string? Redis { get; set; }
  public static string? LogServerName { get; set; }
  public static string? LwaallUrl { get; set; }
  public static string? WmUrl { get; set; }
  public static bool? IsDevelopment { get; set; } = false;
  public static bool? IsRequiredFeedback { get; set; } = true;
  public static string? RedisTransactionUrl { get; set; }
  public static int ServicePort { get; set; }
  public static string? LwaallReminder { get; set; }
  public static string Version { get; set; } = "0.9.4.0";

  #endregion properties


  public static void Config(IConfiguration config)
  {
    ServicePort = 6585;
    var currentConfig = config.GetSection("Environment").Value?.Trim().ToUpper();
    switch (currentConfig)
    {
      case "TEST":
        LogServer = "tcp://192.168.0.164:32700/";
        //All_PostgreSqlCon = "Server=192.168.0.247;Port=5432;Database=IOT_DB;User Id= postgres;Password=Abc@1234;";
        AllSqlCon =
          "Server=.;Database=GameNet;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;";
        Redis = "192.168.0.245:6379";
        LogServerName = "IOTReminderServer";
        RedisTransactionUrl = "http://192.168.0.231:6380/api/";
        LwaallUrl = "http://192.168.0.231:3030/api/";
        LwaallReminder = "http://192.168.0.231:5030/api/";
        WmUrl = "http://192.168.0.231:5050/api/";
        IsDevelopment = true;
        IsRequiredFeedback = true;
        break;
      case "RELEASE":
        LogServer = "tcp://10.10.2.48:32700/";
        AllSqlCon =
          // "Server=sa;Database=DataAcquisitionOEE;User Id=sa;Password=12345678";
          "Server=DESKTOP-8852LTQ;Database=GameNet;Trusted_Connection=False;TrustServerCertificate=True;Encrypt=False;";
        Redis = "10.10.2.29:6379";
        LogServerName = "IOTReminderServer";
        RedisTransactionUrl = "http://10.10.2.29:6380/api/";
        LwaallUrl = "http://10.10.2.29:3030/api/";
        WmUrl = "http://10.10.2.29:5050/api/";
        LwaallReminder = "http://10.10.2.29:5030/api/";
        IsDevelopment = false;
        IsRequiredFeedback = true;
        break;
      case "Server":
        LogServer = "tcp://192.168.1.78:32700/";
        AllSqlCon =
          // "Server=sa;Database=DataAcquisitionOEE;User Id=sa;Password=12345678";
          "Server=DESKTOP-8852LTQ;Database=GameNet;Trusted_Connection=False;TrustServerCertificate=True;Encrypt=False;";
        Redis = "192.168.1.166:6379";
        LogServerName = "IOTReminderServer";
        RedisTransactionUrl = "http://192.168.1.166:6380/api/";
        LwaallUrl = "http://192.168.1.166:3030/api/";
        WmUrl = "http://192.168.1.166:5050/api/";
        LwaallReminder = "http://192.168.1.166:5030/api/";
        IsDevelopment = true;
        IsRequiredFeedback = false;
        break;
    }
  }

  public static ResponseDto? GenerateResponse(HttpStatusCode statusCode, string message, object? result = null,
    int total = 0, int page = 1, int perPage = 10)
    => new()
    {
      StatusCode = (int)statusCode,
      Message = new List<string>() { message },
      Result = result,
      Total = total,
      Page = page,
      PerPage = perPage
    };
}

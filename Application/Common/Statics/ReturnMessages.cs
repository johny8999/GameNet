namespace Application.Common.Statics;

public static class ReturnMessages
{
  public const string Length = "The {0} value should be {1} characters.";
  public const string Guid = "The {0} as guid not valid.";
  public const string MinimumLength = "The {0} Less Than Allowed Character Length";
  public const string MaximumLength = "The {0} More Than Allowed Character Length";
  public const string Characters = "The {0} contains invalid character";
  public const string TypeNumber = "The {0} Should only Contain Digits";
  public const string MacAddress = "Invalid MAcAddress";
  public const string Serial = "Serial Should Be 18 Digits";
  public const string ExpireDate = "You cannot enter days before today.";
  public const string DayToExpire = "The number of days until expiration is invalid!";
  public const string DeviceModelSerial = "Device Model Serial Should Be 8 Digits";

  #region Successful

  public static string SuccessfulAdd(string model) => $"Added {model} Successfully.";
  public static string SuccessfulDelete(string model) => $"Deleted {model} Successfully.";
  public static string SuccessfulUpdate(string model) => $"Updated {model} Successfully.";
  public static string SuccessfulGet(string model) => $"Successful {model}";
  public static string SuccessfulGet() => "Successful.";

  #endregion Successful

  #region Faile

  public static string Faile() => "Failed.";
  public static string FailedAdd(string model) => $"Adding {model} Failed.";
  public static string FailedDelete(string model) => $"Deleting {model} Failed.";
  public static string FailedUpdate(string model) => $"Updating {model} Failed.";
  public static string FailedGet(string model) => $"Failed  {model}";

  #endregion Faile

  #region General

  public static string Exception => "Internal Server Error.";
  public static string Douplicate(string name) => $"{name} Is Douplicate.";

  public static string RequiredField(string field) => $"{field} Is Required.";
  public static string Format(string field) => $"{field} Is Invalid.";
  public static string ContainsInvalidCharacter(string field) => $"{field} Contains Invalid Character(s).";
  public static string OutOfRange(string field, int min, int max) => $"{field} Must Be Between {min}-{max}.";
  public static string AlreadyExist(string model) => $"This {model} Already Exist!";
  public static string NotExist(string model) => $"This {model} Not Exist!";
  public static string NoDeviceModelForSerial() => "Serial Number Doesn't Belong To a Device Model";

  public static string BetweenError(short minLenght, short maxLenght, string model) =>
    $"This {model} Lenght Must Be Between {minLenght} And {maxLenght}";

  public static string GeneralPrint(string model) => $"{model}";

  #endregion General
}

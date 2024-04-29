namespace Application.Common.Statics;

public static class AuthConst
{
  public const string SecretCode = "It is secret code for jwt; jwt is abbreviation of Json Web Token";
  public const string Audience = "SinaShop";
  public const string Issuer = "SinaShop";
  public const string SecretKey = "q6zOsfFfpTv5lNFRgfi8VizQCckeFzL0";
  public const string CookieName = "SinaShopAuth";
  public const int LimitToResendSmsInMinute = 2;
}

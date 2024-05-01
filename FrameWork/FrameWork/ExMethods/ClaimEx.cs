using System.Security.Claims;

namespace FrameWork.ExMethods;

public static class ClaimEx
{
  public static string GetClaim(this IEnumerable<Claim> claims, string claimName)
  {
    return claims.Where(a => a.Type == claimName).Select(a => a.Value).SingleOrDefault();
  }

  public static string GetUserId(this ClaimsPrincipal user)
  {
    return user.Claims.Where(a => a.Type == "Id").Select(a => a.Value).SingleOrDefault();
  }

  public static string GetSellerId(this ClaimsPrincipal user)
  {
    return user.Claims.Where(a => a.Type == "SellerId").Select(a => a.Value).SingleOrDefault();
  }

  public static bool GetSellerConfirmed(this ClaimsPrincipal user)
  {
    return user.Claims.Where(a => a.Type == "SellerConfirmed").Select(a => Convert.ToBoolean(a.Value ?? "false"))
      .SingleOrDefault();
  }
}

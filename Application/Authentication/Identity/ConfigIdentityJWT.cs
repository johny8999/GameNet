using System.Text;
using FrameWork.Utility;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Application.Authentication.Identity;

public static class ConfigIdentityJwt
{
  public static void AddJwtAuthentication(this IServiceCollection services)
  {
    services.AddAuthentication(opt =>
    {
      opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
      opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(opt =>
    {
      opt.RequireHttpsMetadata = false;
      opt.TokenValidationParameters = new TokenValidationParameters
      {
        ClockSkew = TimeSpan.Zero,
        RequireSignedTokens = true,

        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(AuthConst.SecretCode)),

        RequireExpirationTime = true,
        ValidateLifetime = true,

        ValidateAudience = true,
        ValidAudience = AuthConst.Audience,

        ValidateIssuer = true,
        ValidIssuer = AuthConst.Issuer,
      };
    });
  }

  public static void UseJwtAuthentication(this IApplicationBuilder app)
  {
    //TODO:Correct and change code to data store
    //   app.UseMiddleware<JwtAuthenticationWebAppMiddleware>();
    app.UseAuthentication();
    app.UseAuthorization();
  }
}

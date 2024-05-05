using Domain.Models;
using Infra.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Authentication.Identity;

public static class IdentityConfig
{
  public static IdentityBuilder AddCustomIdentity(this IServiceCollection services)
  {
    return services.AddIdentityApiEndpoints<TblUsers>(opt =>
      {
        opt.SignIn.RequireConfirmedAccount = false;
        opt.SignIn.RequireConfirmedEmail = false;
        opt.SignIn.RequireConfirmedPhoneNumber = true;

        opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@";
        opt.User.RequireUniqueEmail = false;

        opt.Password.RequireDigit = false;
        opt.Password.RequireLowercase = false;
        opt.Password.RequiredLength = 4;
        opt.Password.RequiredUniqueChars = 1;
        opt.Password.RequireNonAlphanumeric = false;
        opt.Password.RequireUppercase = false;

        opt.Lockout.AllowedForNewUsers = true;
        opt.Lockout.DefaultLockoutTimeSpan = new TimeSpan(0, 15, 0);
        opt.Lockout.MaxFailedAccessAttempts = 3;
      })
      .AddEntityFrameworkStores<MainContext>()
      .AddDefaultTokenProviders();
  }
}

using Application.Authentication.JWT;
using Application.Common.Responses;
using Application.Interfaces;
using Application.Seed.Main;
using Application.Seed.Role;
using Application.Seed.User;
using Application.Seed.UserRole;
using Application.Services;
using FrameWork.Services;
using Infra.Data.Repositories.Entity;
using Infra.Data.Repositories.Roles;
using Infra.Data.Repositories.UserRole;
using Infra.Data.Repositories.Users;
using Logger.Serilog;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.IOC;

public static class DependencyInjection
{
  public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddHttpClient();

    services.AddSingleton<ISerilogger, Serilogger>();
    services.AddScoped<IUserApplication, UserApplication>();
    services.AddScoped<IUserRepository, UserRepository>();

    services.AddScoped<IJwtBuilder, JwtBuilder>();

    services.AddScoped<IRoleApplication, RoleApplication>();
    services.AddScoped<IUserRoleRepository, UserRoleRepository>();


    services.AddScoped<IRoleRepository, RoleRepository>();
    services.AddScoped<IRoleRepository, RoleRepository>();


    services.AddScoped<ISubEntityApplication, SubEntityApplication>();
    services.AddScoped<ISubEntityRepository, SubEntityRepository>();

    #region Seed

    {
      services.AddTransient<ISeedRoles, SeedRoles>();
      services.AddTransient<ISeedUser, SeedUser>();
      services.AddTransient<ISeedUserRole, SeedUserRole>();
      services.AddTransient<ISeedMain, SeedMain>();
    }

    #endregion Seed


    services.AddSingleton<IResponse, Response>();
  }
}

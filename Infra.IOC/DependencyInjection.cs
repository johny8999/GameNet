using Application.Common.Responses;
using Application.Interfaces;
using Application.Services;
using Infra.Data.Repositories.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.IOC;

public static class DependencyInjection
{
  public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddHttpClient();
  //  services.AddDbContext<MainContext>(opt => opt.UseSqlServer(StaticData.AllSqlCon));

    services.AddScoped<IUserApplication, UserApplication>();
    services.AddScoped<IUserRepository, UserRepository>();


    //services.AddSingleton<ISerilogger, Serilogger>();
    services.AddSingleton<IResponse, Response>();
  }
}

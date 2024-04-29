using Domain.Interfaces;
using FrameWork.Services;
using Infra.Data.Repositories;
using Logger.Serilog;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.IOC;

public static class DependencyInjection
{
  public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
  {
    // services.AddScoped<IOrderOperationService, OrderOperationService>();

    services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    services.AddSingleton<ISerilogger, Serilogger>();
    services.AddHttpClient();
  }
}

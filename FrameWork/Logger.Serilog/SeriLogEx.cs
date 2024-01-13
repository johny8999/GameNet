using Microsoft.AspNetCore.Builder;
using Serilog;
using Serilog.Events;

namespace Logger.Serilog
{
    public static class SeriLogEx
    {
        public static void UseSeriLog_SqlServer(this ConfigureHostBuilder webHostBuilder)
        {
            webHostBuilder.UseSerilog((builder, logger) =>
            {
                logger = new SerilogConfig().ConfigSqlServer(LogEventLevel.Debug);
                logger.CreateLogger();
            });
        }

        public static void UseSeriLog_Files(this ConfigureHostBuilder webHostBuilder)
        {
            webHostBuilder.UseSerilog((builder, logger) =>
            {
              logger = new SerilogConfig().ConfigFile(LogEventLevel.Error);
              logger.CreateLogger();
            });
        }
    }
}

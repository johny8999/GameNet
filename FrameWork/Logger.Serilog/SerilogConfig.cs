using FrameWork.Utility;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;

namespace Logger.Serilog
{
    class SerilogConfig
    {
        public LoggerConfiguration ConfigSqlServer(LogEventLevel logEventLevel)
        {
            var columnOpt = new ColumnOptions();
            columnOpt.Store.Remove(StandardColumn.Properties);
            columnOpt.Store.Add(StandardColumn.LogEvent);
            columnOpt.LogEvent.DataLength = -1;
            columnOpt.PrimaryKey = columnOpt.TimeStamp;
            columnOpt.TimeStamp.NonClusteredIndex = true;

            return new LoggerConfiguration()
                .Enrich.FromLogContext()
                .MinimumLevel.Is(logEventLevel)
                .WriteTo.MSSqlServer(
                  StaticData.LogServerName,
                    new MSSqlServerSinkOptions
                    {
                        AutoCreateSqlTable = true,
                        TableName = "GameNetLog",
                        BatchPeriod = new TimeSpan(0, 0, 1)
                    },
                    columnOptions: columnOpt);
        }

        public LoggerConfiguration ConfigFile(LogEventLevel logEventLevel)
        {
          return FileLoggerConfigurationExtensions.File(new LoggerConfiguration()
            .Enrich.FromLogContext()
            .MinimumLevel.Is(logEventLevel)
            .WriteTo, @"C:\log\log.txt", rollingInterval: RollingInterval.Month);
        }
    }
}

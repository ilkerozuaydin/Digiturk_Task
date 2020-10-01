using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Serilog;
using Serilog.Core;
using System;

namespace Core.CrossCuttingConcerns.Logging.SeriLog
{
    public class SeriLogger : ILogger
    {
        private readonly Logger _logger;

        public SeriLogger()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json").Build();

            _logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }

        public void Error(ErrorLogDetail logDetail)
        {
            _logger.Error(JsonConvert.SerializeObject(logDetail));
        }

        public void Info(InfoLogDetail logDetail)
        {
            _logger.Information(JsonConvert.SerializeObject(logDetail));
        }
    }
}
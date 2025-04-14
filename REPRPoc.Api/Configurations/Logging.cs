using Serilog;

namespace REPRPoc.Api.Configurations
{
    public static class Logging
    {
        public static IHostBuilder ConfigureLogging(this IHostBuilder host)
        {
            var logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

            host.ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddSerilog(logger);
            });

            return host;
        }
    }
}

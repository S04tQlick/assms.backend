namespace assms.api.Helpers;

public static class AmssLogger
{
    public static Logger CreateLogger() =>
        new LoggerConfiguration()
            .WriteTo.Console(outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss}] {Level:u3} {Message:lj} {Exception} {NewLine}")
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .CreateLogger();
}
using System.Globalization;
using Destructurama;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;

namespace LibraryProject.App.Setup;

internal static class HostBuilderExtensions
{
    internal static void AddSeriLog(this WebApplicationBuilder builder)
    {
        var serviceProvider = builder.Services.BuildServiceProvider();
        ArgumentNullException.ThrowIfNull(serviceProvider);

        Log.Logger = new LoggerConfiguration()
            .WriteTo.MSSqlServer(Configuration.ConnectionString, sinkOptions: new MSSqlServerSinkOptions { TableName = "LogEvent", AutoCreateSqlTable = true}, formatProvider: CultureInfo.GetCultureInfo("tr-TR"))
            .MinimumLevel.Information()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
            .MinimumLevel.Override("System", LogEventLevel.Error)
            .Destructure.UsingAttributes()
            .CreateLogger();

        builder.Host.UseSerilog();
    }
}
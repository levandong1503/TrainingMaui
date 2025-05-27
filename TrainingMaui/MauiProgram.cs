using CommunityToolkit.Maui;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Telerik.Maui.Controls.Compatibility;
using TrainingMaui.DataAccess.Models;
using TrainingMaui.UI.Fonts.TelerikFont;
using TrainingMaui.Utils.Encrypted;

namespace TrainingMaui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseTelerik()
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddTelerikFont();
            })
            .UseMauiCommunityToolkit(options =>
            {
                options.SetShouldEnableSnackbarOnWindows(true);
            });

            builder.RegisterLog();

#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }

        private static MauiAppBuilder RegisterLog(this MauiAppBuilder builder)
        {
            // Build a temporary service provider to resolve configuration
            var serviceProvider = builder.Services.BuildServiceProvider();
            var configuration = serviceProvider.GetService<IConfiguration>();
            LogSettingModel logSetting;
            try
            {
                logSetting = configuration?.GetSection("LogSettings").Get<LogSettingModel>();
            }
            catch (InvalidOperationException ex)
            {
                return builder;
            }

            if (logSetting == null)
            {
                return builder;
            }
            // Configure Serilog
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .MinimumLevel.Override("Default", LogEventLevel.Fatal)
                .MinimumLevel.Override("Microsoft", LogEventLevel.Fatal)
                .MinimumLevel.Override("System", LogEventLevel.Fatal)
                .WriteTo.File(
                    new EncryptedTextFormatter(),
                    logSetting.LogPath,
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: logSetting.LogKeepDays
                )
                .CreateLogger();
            // Add Serilog to the logging providers
            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog();
            return builder;
        }

    }
}
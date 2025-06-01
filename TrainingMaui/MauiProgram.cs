using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Telerik.Maui.Controls.Compatibility;
using TrainingMaui.CoreMVVM.MVVM;
using TrainingMaui.CoreMVVM.Navigation;
using TrainingMaui.DataAccess.Models;
using TrainingMaui.Features.Music.Pages;
using TrainingMaui.Features.Music.ViewModels;
using TrainingMaui.Features.Music.Views;
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
                fonts.AddFont("telerikfontexamples.ttf", "TelerikFontExamples");
                //fonts.AddTelerikFont();
            });
            //.UseMauiCommunityToolkit(options =>
            //{
            //    options.SetShouldEnableSnackbarOnWindows(true);
            //});

            builder.RegisterPages();
            builder.RegisterContentView();
            builder.RegisterServices();
            builder.RegisterLog();

#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }

        private static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<IAppNavigator, AppNavigator>();
            return builder;
        }

        private static MauiAppBuilder RegisterPages(this MauiAppBuilder builder)
        {
            builder.Services.AddPage<Home, HomeViewModel>();
            return builder;
        }

        private static MauiAppBuilder RegisterContentView(this MauiAppBuilder builder)
        {
            builder.Services.AddContentView<Dashboard, DashboardViewModel>();
            builder.Services.AddContentView<ChatView, ChatViewModel>();
            return builder;
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

        private static IServiceCollection AddPage<TPage, TViewModel>(this IServiceCollection services)
            where TPage : BasePage where TViewModel : BaseViewModel
        {
            services.AddTransient<TPage>();
            services.AddTransient<TViewModel>();
            return services;
        }

        private static IServiceCollection AddContentView<TContentView, TViewModel>(this IServiceCollection services)
            where TContentView : ContentView where TViewModel : BaseViewModel
        {
            services.AddTransient<TContentView>();
            services.AddTransient<TViewModel>();
            return services;
        }
    }
}
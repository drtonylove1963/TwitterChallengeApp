using System;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Tweetinvi;
using TwitterChallenge.Helpers;
using TwitterChallenge.Interfaces;
using TwitterChallenge.Services;


namespace TwitterChallenge
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            // Setup SeriLog Logger
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                .Enrich.FromLogContext()
                .WriteTo.File("D:\\Projects\\JackHenry\\TwitterChallengeApp\\TwitterChallenge\\log.txt", fileSizeLimitBytes: null)
                .CreateLogger();

            Log.Logger.Information("Application Starting");

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<ITwitterFeedService, TwitterFeedService>();
                    services.AddSingleton<IColorLogWriter, ColorLogWriter>();
                    services.AddSingleton<IStringHelper, StringHelper>();
                    services.AddSingleton<ITwitterHelperService, TwitterHelperService>();
                })
                .UseSerilog()
                .Build();

            var svc = ActivatorUtilities.CreateInstance<TwitterFeedService>(host.Services);

            svc.Run();
        }

        static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile(
                    $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json",
                    optional: true)
                .AddEnvironmentVariables();
        }
    }
}

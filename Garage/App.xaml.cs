using System;
using System.Windows;
using Data;
using Garage.Util;
using Garage.View;
using Garage.Viewmodel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services;

namespace Garage
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = new HostBuilder()
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder.AddJsonFile("appsettings.json");
                })
                .ConfigureServices((context, services) =>
                {
                    services
                        .AddSingleton(context.Configuration)
                        .AddDbContext<GarageContext>(optionBuilder =>
                            {
                                optionBuilder.UseSqlServer(context.Configuration.GetConnectionString("GarageDb"));
                            },
                            ServiceLifetime.Transient)
                        .AddTransient<IUnitOfWorkFactory, UnitOfWorkFactory>()
                        .AddTransient<IQueryService, QueryService>()
                        .AddTransient<IFileExporterFactory, FileExporterFactory>()
                        .AddTransient<IMainWindowViewModel, MainWindowViewModel>()
                        .AddTransient<MainWindow>();
                })
                .Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Services.GetRequiredService<MainWindow>().Show();
        }

        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            await _host.StartAsync();
        }

        private async void Application_Exit(object sender, ExitEventArgs e)
        {
            using (_host)
            {
                await _host.StopAsync(TimeSpan.FromSeconds(5));
            }
        }
    }
}

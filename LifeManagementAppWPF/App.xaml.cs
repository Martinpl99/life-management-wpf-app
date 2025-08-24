using AutoMapper;
using LifeManagementAppWPF.Dialogs.LoggingDialog.Interfaces;
using LifeManagementAppWPF.Dialogs.LoggingDialog.View;
using LifeManagementAppWPF.Dialogs.LoggingDialog.ViewModel;
using LifeManagementAppWPF.Global;
using LifeManagementAppWPF.MainWnd.Interfaces;
using LifeManagementAppWPF.MainWnd.View;
using LifeManagementAppWPF.MainWnd.ViewModel;
using LifeManagementAppWPF.Sources.TabItems.Interface;
using LifeManagementAppWPF.Sources.TabItems.ViewModel;
using LiveManagementAppDatabase.DatabaseServices.Interfaces;
using LiveManagementAppDatabase.DatabaseServices.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Windows;

namespace LifeManagementAppWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var services = new ServiceCollection();

            ConfigureServices(services);

            #region Logger
            ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
            #endregion

            #region AutoMapper
            #endregion

            ServiceProvider = services.BuildServiceProvider();
            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.ShowDialog();
            Shutdown();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            //AppContext
            services.AddSingleton<IApplicationContext, ApplicationContext>();

            //Services
            services.AddTransient<IUserService, UserService>();

            //View Models
            services.AddSingleton<IMainWindowVM,MainWindowVM>();
            services.AddTransient<ILoggingDialogVM, LoggingDialogVM>();
            services.AddTransient<IUserInfoTabViewModel, UserInfoTabVM>();

            //Views
            services.AddSingleton<MainWindow>();
            services.AddTransient<LoggingDialog>();

            //Utils
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<UserProfile>();
            });

            services.AddLogging();
        }
    }

}

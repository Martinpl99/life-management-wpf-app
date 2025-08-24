using LifeManagementAppWPF.Dialogs.LoggingDialog.Interfaces;
using LifeManagementAppWPF.Dialogs.LoggingDialog.View;
using LifeManagementAppWPF.Dialogs.LoggingDialog.ViewModel;
using LifeManagementAppWPF.Global;
using LifeManagementAppWPF.MainWnd.Interfaces;
using LifeManagementAppWPF.MainWnd.View;
using LifeManagementAppWPF.MainWnd.ViewModel;
using Microsoft.Extensions.DependencyInjection;
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

            ServiceProvider = services.BuildServiceProvider();
            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.ShowDialog();
            mainWindow.Close();
            Shutdown();

        }

        private void ConfigureServices(IServiceCollection services)
        {
            //AppContext
            services.AddSingleton<IApplicationContext, ApplicationContext>();

            //Services


            //View Models
            services.AddSingleton<IMainWindowVM,MainWindowVM>();
            services.AddTransient<ILoggingDialogVM, LoggingDialogVM>();

            //Views
            services.AddSingleton<MainWindow>();
            services.AddTransient<LoggingDialog>();
        }
    }

}

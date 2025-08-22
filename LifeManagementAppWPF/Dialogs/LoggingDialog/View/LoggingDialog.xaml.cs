using LifeManagementAppWPF.Dialogs.LoggingDialog.Interfaces;
using MahApps.Metro.Controls;

namespace LifeManagementAppWPF.Dialogs.LoggingDialog.View
{
    /// <summary>
    /// Interaction logic for OpenAppWindow.xaml
    /// </summary>
    public partial class LoggingDialog : MetroWindow
    {
        public LoggingDialog(ILoggingDialogVM loggingDialogVM)
        {
            InitializeComponent();
            DataContext = loggingDialogVM;
        }
    }
}

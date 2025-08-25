using LifeManagementAppWPF.MainWnd.Interfaces;
using MahApps.Metro.Controls;

namespace LifeManagementAppWPF.MainWnd.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow(IMainWindowVM mainWindowVM)
        {
            InitializeComponent();
            DataContext = mainWindowVM;
        }
    }
}
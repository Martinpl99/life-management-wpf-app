using LifeManagementAppWPF.Sources.TabItems.Interface;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace LifeManagementAppWPF.MainWnd.Interfaces
{
    public interface IMainWindowVM
    {
        ICommand ButtonClickCommand { get; set; }
        ICommand WindowLoadedCommand { get; set; }
        ObservableCollection<ITabItemVM> TabItems { get; set; }
    }
}

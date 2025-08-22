using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LifeManagementAppWPF.MainWnd.Interfaces
{
    public interface IMainWindowVM
    {
        ICommand ButtonClickCommand { get; set; }
        ICommand WindowLoadedCommand { get; set; }
    }
}

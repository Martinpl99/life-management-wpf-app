using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LifeManagementAppWPF.Common.Windows.Interfaces
{
    /// <summary>
    /// Interface to close dialog in MVVM approach. 
    /// Implement interface and add OkCancelDialogBehavior to Window
    /// </summary>
    internal interface IOkWindow
    {
        event Action OnOkEvent;
    }
}

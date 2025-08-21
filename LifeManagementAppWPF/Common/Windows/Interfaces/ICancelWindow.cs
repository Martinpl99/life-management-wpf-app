using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeManagementAppWPF.Common.Windows.Interfaces
{
    /// <summary>
    /// Interface to close dialog in MVVM approach. 
    /// Implement interface and add OkCancelDialogBehavior to Window
    /// </summary>
    internal interface ICancelWindow
    {
        event Action OnCancelEvent;
    }
}

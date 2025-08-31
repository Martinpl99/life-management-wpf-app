using LifeManagementAppWPF.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeManagementAppWPF.Common.Interfaces
{
    /// <summary>
    /// Should be implemented when Grid with progress spin has been added to view
    /// </summary>
    public interface IDatabaseOperationPerforming
    {
        IDatabaseStatus DatabaseStatus { get; }
    }
}

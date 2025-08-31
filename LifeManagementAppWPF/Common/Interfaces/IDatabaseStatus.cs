using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeManagementAppWPF.Common.Interfaces
{
    public interface IDatabaseStatus
    {
        void StartDatabaseOperation();
        void EndDatabaseOperation();
    }
}

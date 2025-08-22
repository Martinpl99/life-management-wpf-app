using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeManagementAppWPF.Global
{
    public interface IApplicationContext
    {
        Guid UserId { get; set; }
    }
}

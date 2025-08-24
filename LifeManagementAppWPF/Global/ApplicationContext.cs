using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeManagementAppWPF.Global
{
    public class ApplicationContext : IApplicationContext
    {
        public Guid UserId { get; set; } = Guid.Parse("01988695-61c0-7259-9f76-f03d4b23ec29");
    }
}

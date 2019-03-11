using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSolution.Core.Entities
{
    public class SystemConfigurations:Entity
    {
        public long ModuleId { get; set; }
        public long ScreenId { get; set; }
        public bool IsActive { get; set; }
    }
}

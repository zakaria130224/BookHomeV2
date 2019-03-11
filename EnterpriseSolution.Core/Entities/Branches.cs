using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSolution.Core.Entities
{
    public class Branches:Entity
    {
        public virtual string Code { get; set; }

        public virtual string Name { get; set; }

        public virtual string City { get; set; }

        public virtual string Address { get; set; }

        public virtual bool IsActive { get; set; }
   
    }
}

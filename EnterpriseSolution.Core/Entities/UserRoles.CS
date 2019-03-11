using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSolution.Core.Entities
{
    [Table("UserRoles")]
    public  class UserRoles :Entity
    {
        public  string UserRole { get; set; }

        public  bool IsActive { get; set; }
      
    }
}

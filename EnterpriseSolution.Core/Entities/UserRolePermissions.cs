using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSolution.Core.Entities
{
    [Table("UserRolePermissions")]
    public class UserRolePermissions:Entity
    {
        public  long UserId { get; set; }

        public  long UserRoleId { get; set; }

        public  Users User { get; set; }

        public  IEnumerable<UserRoles> UserRoles { get; set; }
    }
}

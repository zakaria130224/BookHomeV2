using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSolution.Core.Entities
{
    [Table("Users")]
    public class Users : Entity
    {
        public  string FirstName { get; set; }

        public  string LastName { get; set; }
        
        public  string Email { get; set; }

        public  string Password { get; set; }

        public  string MobileNo { get; set; }

        public  long RoleId { get; set; }

        public  bool IsActive { get; set; }

        public  long BranchId { get; set; }
        
        public string UserId { get; set; }
        
        public string UserName { get; set; }

        public DateTime? LastPasswordChangeDate { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSolution.Core.DataModel
{
    public class UserDetailsDataModel
    {

        public long UserId { get; set; }

        public string UserName { get; set; } //Table Coulmn UserName

        public string UserPin { get; set; } //Table Coulmn UserId

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MobileNo { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }

        public long RoleId { get; set; }

        public string RoleName { get; set; }
    }
}

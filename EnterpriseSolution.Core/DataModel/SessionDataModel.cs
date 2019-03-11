using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSolution.Core.DataModel
{
    public class SessionDataModel
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public long UserId { get; set; }
        public long RoleId { get; set; }
        public string RoleName { get; set; }
        public long BranchId { get; set; }
        public string BranchName { get; set; }
        public string BranchCode { get; set; }
        public DateTime? LastPasswordChangeDate { get; set; }
    }
}

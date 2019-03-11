using EnterpriseSolution.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSolution.Core.Services
{
    public interface IUserRoleService
    {
        IEnumerable<UserRoles> GetListOfUserRole();

        UserRoles Insert(UserRoles userRole);

        UserRoles UpdateUserRole(UserRoles userRoles);

        UserRoles GetUserRoleById(long Id);
    }
}

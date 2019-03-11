using EnterpriseSolution.Core.Entities;
using EnterpriseSolution.Core.Repositories;
using EnterpriseSolution.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSolution.Infrastructure.Services
{
    public class UserRoleService : IUserRoleService
    {
        private IRepository<UserRoles> userRoleRepository;
        public UserRoleService(IRepository<UserRoles> userRoleRepository)
        {
            this.userRoleRepository = userRoleRepository;
        }
        public IEnumerable<UserRoles> GetListOfUserRole()
        {
            return userRoleRepository.GetAll();
        }

        public UserRoles GetUserRoleById(long Id)
        {
            return userRoleRepository.Get(Id);
        }

        public UserRoles Insert(UserRoles userRole)
        {
            userRoleRepository.Insert(userRole);
            return userRoleRepository.Get(userRole.Id);
        }

        public UserRoles UpdateUserRole(UserRoles userRoles)
        {
            userRoleRepository.Update(userRoles);
            return userRoleRepository.Get(userRoles.Id);
        }
    }
}

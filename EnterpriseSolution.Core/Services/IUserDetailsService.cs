using EnterpriseSolution.Core.DataModel;
using EnterpriseSolution.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSolution.Core.Services
{
    public interface IUserDetailsService
    {
        IEnumerable<Users> GetListOfUser();

        IEnumerable<UserDetailsDataModel> GetListOfUserDetails();

        IEnumerable<UserRoles> GetListOfUserRoles();

        Users Insert(Users user);

        bool DeleteUser(long userId);

        Users UpdateUser(Users users);

        Users GetUserById(long UserId);

        Users UpdateUserPassword(long usersId, string newPassword,string oldPassword);
    }
}

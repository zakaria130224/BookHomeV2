using EnterpriseSolution.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSolution.Core.DataModel;

namespace EnterpriseSolution.Core.Repositories
{
    public interface IUsersRepository
    {
        IEnumerable<Users> GetUsers();

        Users GetUserById(long userId);

        SessionDataModel GetUserLoginInfo(string userName, string password);

        ClaimsIdentity GetUserIdentity(SessionDataModel user);

        void Save(Users user);

        void Edit(long userId, Users user);

        void Delete(long userId);
    }
}

using EnterpriseSolution.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSolution.Core.DataModel;
using EnterpriseSolution.Core.Entities;
using EnterpriseSolution.Core.Repositories;
using EnterpriseSolution.Core.Shared;

namespace EnterpriseSolution.Infrastructure.Services
{
    public class UserDetailsService : IUserDetailsService
    {
        private IRepository<Users> usersRepository;

        private IRepository<UserRoles> userRolesRepository;

        private IPrefixesService prefixService;

        public UserDetailsService(IRepository<Users> usersRepository, IRepository<UserRoles> userRolesRepository, IPrefixesService prefixService)
        {
            this.usersRepository = usersRepository;
            this.userRolesRepository = userRolesRepository;
            this.prefixService = prefixService;
        }

        public bool DeleteUser(long userId)
        {
            usersRepository.Delete(userId);
            return true;
        }

        public IEnumerable<Users> GetListOfUser()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDetailsDataModel> GetListOfUserDetails()
        {
            var userList = usersRepository.GetAll().AsEnumerable();
            var userRoleList = userRolesRepository.GetAll().AsEnumerable();

            var result = (from u in userList
                          join ur in userRoleList on u.RoleId equals ur.Id
                          select new UserDetailsDataModel
                          {
                              UserId = u.Id,
                              UserName = u.UserName,
                              UserPin = u.UserId,
                              FirstName = u.FirstName,
                              LastName = u.LastName,
                              MobileNo = u.MobileNo,
                              Email = u.Email,
                              RoleId = u.RoleId,
                              IsActive = u.IsActive,
                              RoleName = ur.UserRole
                          }).ToList();

            return result;
        }

        public IEnumerable<UserRoles> GetListOfUserRoles()
        {
            return userRolesRepository.GetAll().ToList();
        }

        public Users GetUserById(long UserId)
        {
            return usersRepository.Get(UserId);
        }

        public Users Insert(Users user)
        {
            user.UserId = prefixService.GetPrefixes(Constants.Prefix.UserId).Prefix;
            user.Password = Constants.GetSecurePassword(user.UserId);
            return usersRepository.Insert(user);
        }

        public Users UpdateUser(Users users)
        {
            return usersRepository.Update(users);
        }

        public Users UpdateUserPassword(long usersId, string newPassword, string oldPassword)
        {
            Users users = usersRepository.Get(usersId);
            if(users.Password.Equals(Constants.GetSecurePassword(oldPassword)))
            {
                users.LastPasswordChangeDate = DateTime.Now;
                users.Password = Constants.GetSecurePassword(newPassword);
                return usersRepository.Update(users);
            }
            return null;
        }
    }
}

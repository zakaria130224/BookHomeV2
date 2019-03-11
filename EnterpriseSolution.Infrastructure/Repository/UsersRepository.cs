using EnterpriseSolution.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSolution.Core.Entities;
using System.Security.Claims;
using EnterpriseSolution.Core.DataModel;
using EnterpriseSolution.Infrastructure.Helpers;
using EnterpriseSolution.Core.Shared;
using NHibernate.Linq;
using EnterpriseSolution.Infrastructure.EnterpriseDbContext;

namespace EnterpriseSolution.Infrastructure.Repository
{
    public class UsersRepository : RepositoryBase, IUsersRepository
    {
        readonly SessionHelper connection;
        private IRepository<Users> userRepository { get; set; }
        private IRepository<Branches> branchRepository { get; set; }
        private IRepository<UserRoles> userRoleRepository { get; set; }
        private DatabaseContext context;
        public UsersRepository(string pConnectionString  , IRepository<Users> userRepository , IRepository<Branches> branchRepository , IRepository<UserRoles> userRoleRepository) : base(pConnectionString)
        {
            //connection = new SessionHelper(connectionString);
            this.userRepository = userRepository;
            this.branchRepository = branchRepository;
            this.userRoleRepository = userRoleRepository;
            context = new DatabaseContext();
        }

        public void Delete(long userId)
        {
            throw new NotImplementedException();
        }

        public void Edit(long userId, Users user)
        {
            throw new NotImplementedException();
        }

        public Users GetUserById(long userId)
        {
            throw new NotImplementedException();
        }

        public ClaimsIdentity GetUserIdentity(SessionDataModel user)
        {
            var identity = new ClaimsIdentity(Constants.ApplicationCookie, ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            identity.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", Constants.ProviderName));
            //identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            //identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.UserName));
            identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
            //identity.AddClaim(new Claim(ClaimTypes.Role, user.IsAdmin == true ? "YES" : "NO"));            
            identity.AddClaim(new Claim("UserId", user.Id.ToString()));            

            // add your own claims if you need to add more information stored on the cookie
            return identity;
        }

        public SessionDataModel GetUserLoginInfo(string userName, string password)
        {
            password = Constants.GetSecurePassword(password);

            var result = (from u in context.Users
                          join ur in context.UserRoles on u.RoleId equals ur.Id
                          join br in context.Branches on u.BranchId equals br.Id
                          where (u.Email.Equals(userName) || u.UserName.Equals(userName)) && u.Password.Equals(password) && u.IsActive.Equals(true)
                          select new SessionDataModel()
                          {
                              Email = u.Email,
                              RoleId = ur.Id,
                              RoleName = ur.UserRole.ToUpper(),
                              UserId = u.Id,
                              Id = u.Id,
                              UserName = u.FirstName + " " + u.LastName,
                              BranchId = br.Id,
                              BranchName = br.Name,
                              BranchCode = br.Code,
                              LastPasswordChangeDate = u.LastPasswordChangeDate
                          }).FirstOrDefault();

            return result;
        }

        public IEnumerable<Users> GetUsers()
        {
          
                var result = (from s in userRepository.GetAll().Where(x => x.IsActive.Equals(true))
                              select new Users
                              {
                                  Id = s.Id,
                                  FirstName = s.FirstName,
                                  LastName = s.LastName,
                                  MobileNo = s.MobileNo,
                                  Email = s.Email,
                                  Password = string.Empty,
                                  RoleId = s.RoleId,
                                  IsActive = s.IsActive
                              }).ToList();

                return result;
            
        }

        public void Save(Users user)
        {
            throw new NotImplementedException();
        }
    }
}

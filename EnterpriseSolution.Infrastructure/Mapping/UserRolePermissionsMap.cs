using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSolution.Core.Entities;
using FluentNHibernate.Mapping;

namespace EnterpriseSolution.Infrastructure.Mapping
{
    public class UserRolePermissionsMap:ClassMap<UserRolePermissions>
    {
        public UserRolePermissionsMap()
        {
            Id();
            LazyLoad();

            Map(x => x.UserId);

            Map(x => x.UserRoleId);

            HasMany<UserRoles>(x => x.UserRoles).Inverse().KeyColumn("Id");
          

        }
    }
}

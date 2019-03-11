using EnterpriseSolution.Core.Entities;
using FluentNHibernate.Mapping;

namespace EnterpriseSolution.Infrastructure.Mapping
{
    public class UsersMap : ClassMap<Users>
    {
        public UsersMap()
        {
            Id(x => x.Id);

            LazyLoad();
            
            Map(x => x.FirstName).Nullable();

            Map(x => x.LastName).Nullable();

            Map(x => x.MobileNo).Nullable();

            Map(x => x.Email).Not.Nullable();

            Map(x => x.Password).Not.Nullable();

            Map(x => x.RoleId).Not.Nullable();

            Map(x => x.IsActive).Not.Nullable();

            Map(x => x.BranchId).Not.Nullable();

            //References(x => x.Branches).Class<Branches>().Columns("BranchId");

        }
    }
}

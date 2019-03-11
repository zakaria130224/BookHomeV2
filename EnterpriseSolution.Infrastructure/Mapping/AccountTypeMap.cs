using EnterpriseSolution.Core.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSolution.Infrastructure.Mapping
{
    public class AccountTypeMap : ClassMap<AccountType>
    {
        public AccountTypeMap()
        {
            Id(x => x.Id);

            LazyLoad();

            Map(x => x.Name).Not.Nullable();

            Map(x => x.Code).Not.Nullable();

            Map(x => x.Description).Nullable();            

            Map(x => x.IsActive).Not.Nullable();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSolution.Core.Entities;
using FluentNHibernate.Mapping;

namespace EnterpriseSolution.Infrastructure.Mapping
{
    public class BranchesMap:ClassMap<Branches>
    {
        public BranchesMap()
        {
            Id(x => x.Id);

            LazyLoad();

            Map(x => x.Name).Not.Nullable();

            Map(x => x.City).Not.Nullable();

            Map(x => x.Code).Not.Nullable();

            Map(x => x.Address).Nullable();

            Map(x => x.IsActive).Not.Nullable().Default("false");

        }
    }
}

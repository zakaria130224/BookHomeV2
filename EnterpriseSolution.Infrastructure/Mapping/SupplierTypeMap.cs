using EnterpriseSolution.Core.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSolution.Infrastructure.Mapping
{
    public class SupplierTypeMap : ClassMap<SupplierType>
    {
        public SupplierTypeMap()
        {
            Id(x => x.Id);

            LazyLoad();

            Map(x => x.SupplierTypeName).Not.Nullable();

            Map(x => x.IsActive).Not.Nullable();
        }
    }
}

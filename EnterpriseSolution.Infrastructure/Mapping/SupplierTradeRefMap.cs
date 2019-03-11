using EnterpriseSolution.Core.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSolution.Infrastructure.Mapping
{
    public class SupplierTradeRefMap : ClassMap<SupplierTradeRef>
    {
        public SupplierTradeRefMap()
        {
            Id(x => x.Id);

            LazyLoad();

            Map(x => x.SupplierId).Not.Nullable();

            Map(x => x.Reference).Not.Nullable();

            Map(x => x.Account).Not.Nullable();

            Map(x => x.Phone).Nullable();

            Map(x => x.Fax).Nullable();

            Map(x => x.City).Nullable();
            
            Map(x => x.State).Nullable();

            Map(x => x.CreatedBy).Not.Nullable();

            Map(x => x.CreatedOn).Not.Nullable();
        }
    }
}

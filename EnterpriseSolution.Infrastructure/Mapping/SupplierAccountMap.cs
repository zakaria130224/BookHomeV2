using EnterpriseSolution.Core.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSolution.Infrastructure.Mapping
{
    public class SupplierAccountMap : ClassMap<SupplierAccount>
    {
        public SupplierAccountMap()
        {
            Id(x => x.Id);

            LazyLoad();

            Map(x => x.SupplierId).Not.Nullable();

            Map(x => x.AccountName).Nullable();

            Map(x => x.AccountNumber).Nullable();

            Map(x => x.BankName).Not.Nullable();

            Map(x => x.BankPhone).Nullable();

            Map(x => x.BankFax).Nullable();

            Map(x => x.BankAddress).Not.Nullable();

            Map(x => x.City).Nullable();

            Map(x => x.State).Nullable();

            Map(x => x.ZipCode).Not.Nullable();

            Map(x => x.CreatedBy).Not.Nullable();

            Map(x => x.CreatedOn).Not.Nullable();

        }
    }
}

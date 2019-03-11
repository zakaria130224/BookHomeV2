using EnterpriseSolution.Core.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSolution.Infrastructure.Mapping
{
    public class AssetSalesMap : ClassMap<AssetSales>
    {
        public AssetSalesMap()
        {
            Id(x => x.Id);

            LazyLoad();

            Map(x => x.AssetId).Not.Nullable();

            Map(x => x.SaleReferenceNo).Not.Nullable();

            Map(x => x.AssetReferenceNo).Not.Nullable();

            Map(x => x.AccumulatedDepreciation).Not.Nullable();

            Map(x => x.Ait).Nullable();

            Map(x => x.Vat).Nullable();

            Map(x => x.SaleValue).Nullable();

            Map(x => x.AssetValue);

            Map(x => x.SaleStatus).Nullable();

            Map(x => x.MakerId).Not.Nullable();

            Map(x => x.CreatedOn).Not.Nullable();

            Map(x => x.CheckerId).Nullable();

            Map(x => x.UpdatedOn).Nullable();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSolution.Core.Entities;
using FluentNHibernate.Mapping;

namespace EnterpriseSolution.Infrastructure.Mapping
{
    public class AssetDetailsMap : ClassMap<AssetDetails>
    {
        public AssetDetailsMap()
        {
            Id(x => x.Id);
            LazyLoad();
            Map(x => x.ItemNumber).Not.Nullable();

            Map(x => x.Description).Nullable();

            Map(x => x.Remarks).Nullable();
            Map(x => x.ItemCost).Nullable();
            Map(x => x.ExpectedDeliveryDate).Nullable();
            Map(x => x.Delivered).Nullable();
            Map(x => x.Inspecred).Nullable();
         
        }
    }
}

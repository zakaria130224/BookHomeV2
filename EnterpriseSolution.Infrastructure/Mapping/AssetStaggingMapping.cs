using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSolution.Core.Entities;
using FluentNHibernate.Mapping;

namespace EnterpriseSolution.Infrastructure.Mapping
{
    public class AssetStaggingMapping : ClassMap<AssetStagging>
    {
        public AssetStaggingMapping()
        {
            Id(x => x.Id);

            LazyLoad();

            Map(x => x.ProductDescription).Nullable();

            //Map(x => x.ContractReference).Nullable();

            Map(x => x.SourceReference).Nullable();

            //Map(x => x.Category).Not.Nullable();

            //Map(x => x.AssetSubCategories).Not.Nullable();

            //Map(x => x.Location).Not.Nullable();

            //Map(x => x.Currency).Not.Nullable();

            Map(x => x.AssestCost).Not.Nullable();

            Map(x => x.Desciption).Not.Nullable();

            Map(x => x.BookDate).Nullable();

            Map(x => x.AcquisitionDate).Nullable();

            Map(x => x.AcquiredDescription).Nullable();

            Map(x => x.ResidualValue).Nullable();

            Map(x => x.OriginalReference).Nullable();

            Map(x => x.CapitalizationDate).Nullable();

            Map(x => x.EffectiveDepriciationDate).Nullable();

            Map(x => x.UsefulLife).Nullable();

            Map(x => x.UsefulLifeType).Nullable();
        }
    }
}

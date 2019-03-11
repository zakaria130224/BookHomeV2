using EnterpriseSolution.Core.Entities;
using FluentNHibernate.Mapping;

namespace EnterpriseSolution.Infrastructure.Mapping
{
    class AssetsMap : ClassMap<Assets>
    {
        public AssetsMap()
        {
            Id(x => x.Id);

            LazyLoad();

            Map(x => x.ProductCode).Not.Nullable();

            Map(x => x.ProductDescription).Nullable();

            Map(x => x.ContractReference).Nullable();

            //Map(x => x.UserReference).Nullable();

            //Map(x => x.SourceReference).Nullable();

            //Map(x => x.SourceCode).Nullable();

            Map(x => x.CategoryId).Not.Nullable();

            Map(x => x.LocationId).Not.Nullable();

            Map(x => x.CurrencyId).Not.Nullable();

            Map(x => x.AssestCost).Not.Nullable();

            Map(x => x.Desciption).Not.Nullable();

            Map(x => x.BookDate).Nullable();

            //Map(x => x.AcquisitionDate).Nullable();

            //Map(x => x.AcquiredDescription).Nullable();

            Map(x => x.ResidualValue).Nullable();

            //Map(x => x.OriginalReference).Nullable();

            //Map(x => x.CapitalizationDate).Nullable();

            //Map(x => x.EffectiveDepriciationDate).Nullable();

            Map(x => x.UsefulLife).Nullable();

            Map(x => x.UsefulLifeType).Nullable();

            //Map(x => x.SuspendedDepreciation).Nullable();

            //Map(x => x.SuspensionDate).Nullable();

            Map(x => x.AuthorizationStatusId).Not.Nullable();

            //Map(x => x.LocationDescribtion).Nullable();

            //Map(x => x.CatagoryDetails).Nullable();

            Map(x => x.MakerId).Not.Nullable();

            Map(x => x.SubCategoryId).Not.Nullable();

            Map(x => x.CheckerId).Nullable();

        }
    }
}

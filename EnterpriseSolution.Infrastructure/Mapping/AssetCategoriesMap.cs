using EnterpriseSolution.Core.Entities;
using FluentNHibernate.Mapping;

namespace EnterpriseSolution.Infrastructure.Mapping
{
    public class AssetCategoriesMap : ClassMap<AssetCategories>
    {
        public AssetCategoriesMap()
        {
            Id(x => x.Id);

            LazyLoad();

            Map(x => x.AssetCategory).Not.Nullable();

            Map(x => x.ShortCode).Not.Nullable();

            Map(x => x.CategoryDescription).Nullable();

            Map(x => x.IsActive).Not.Nullable();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSolution.Core.Entities;
using FluentNHibernate.Mapping;

namespace EnterpriseSolution.Infrastructure.Mapping
{
    class AssetSubCategoryMap:ClassMap<AssetSubCategories>
    {
        public AssetSubCategoryMap()
        {
            Id(x => x.Id);

            LazyLoad();

            Map(x => x.AssetSubCategory);

            Map(x => x.SubCategoriesDescription);

            Map(x => x.AssetCategoryId);

            Map(x => x.IsActive);

            Map(x => x.ShortCode);

        }
    }
}

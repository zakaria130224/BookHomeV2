using EnterpriseSolution.Core.Entities;
using FluentNHibernate.Mapping;

namespace EnterpriseSolution.Infrastructure.Mapping
{
    public class GlTypesMap : ClassMap<GlTypes>
    {
        public GlTypesMap()
        {
            Id(x => x.Id);

            LazyLoad();

            Map(x => x.Name).Not.Nullable();

            Map(x => x.Code).Not.Nullable();

            Map(x => x.Description).Nullable();

            Map(x => x.IsActive).Not.Nullable();
        }
    }
}

using EnterpriseSolution.Core.Entities;
using FluentNHibernate.Mapping;
namespace EnterpriseSolution.Infrastructure.Mapping
{
    public class LocationsMap : ClassMap<Locations>
    {
        public LocationsMap()
        {
            Id(x => x.Id);

            LazyLoad();

            Map(x => x.LocationCode).Not.Nullable();

            Map(x => x.LocationName).Not.Nullable();

            Map(x => x.LocationDescription).Nullable();

            Map(x => x.IsActive).Not.Nullable();
        }
    }
}

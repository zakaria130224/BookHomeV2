using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSolution.Core.Entities;
using FluentNHibernate.Mapping;

namespace EnterpriseSolution.Infrastructure.Mapping
{
    public class SuppliersMap:ClassMap<Suppliers>
    {
        public SuppliersMap()
        {
            Id(x => x.Id);

            LazyLoad();

            Map(x => x.SupplierTypeId).Not.Nullable();

            Map(x => x.SupplierName).Not.Nullable();

            Map(x => x.SupplierBIN).Nullable();

            Map(x => x.SupplierTIN).Nullable();

            Map(x => x.TradeLicense).Nullable();

            Map(x => x.ContactPerson).Nullable();

            Map(x => x.PhysicalAddress).Nullable();

            Map(x => x.City).Nullable();

            Map(x => x.State).Nullable();

            Map(x => x.Country).Nullable();

            Map(x => x.ZipCode).Nullable();

            Map(x => x.SubsidiaryPhone).Nullable();

            Map(x => x.SubsidiaryFax).Nullable();

            Map(x => x.HeadquarterPhone).Nullable();

            Map(x => x.HeadquarterFax).Nullable();

            Map(x => x.YearsInBusiness);

            Map(x => x.Incorporated);

            Map(x => x.Email).Nullable();

            Map(x => x.MobileNo);
            
            Map(x => x.CreatedBy);

            Map(x => x.CreatedOn);
        }
    }
}

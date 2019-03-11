using EnterpriseSolution.Core.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSolution.Infrastructure.Mapping
{
    public class CurrencyMap : ClassMap<Currency>
    {
        public CurrencyMap()
        {
            Id(x => x.Id);

            LazyLoad();

            Map(x => x.CurrencyCode).Not.Nullable();

            Map(x => x.CurrencyName).Nullable();
        }
    }
}

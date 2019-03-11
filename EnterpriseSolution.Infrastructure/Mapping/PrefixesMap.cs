using EnterpriseSolution.Core.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSolution.Infrastructure.Mapping
{
    public class PrefixesMap :  ClassMap<Prefixes>
    {
        public PrefixesMap()
        {
            Id(x => x.Id);

            LazyLoad();

            Map(x => x.PrefixFor).Not.Nullable();

            Map(x => x.Prefix).Not.Nullable();

            Map(x => x.SerialNo).Not.Nullable();
        }
    }
}

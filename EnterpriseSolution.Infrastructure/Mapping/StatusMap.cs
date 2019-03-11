using EnterpriseSolution.Core.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSolution.Infrastructure.Mapping
{
    public class StatusMap : ClassMap<Status>
    {
        public StatusMap()
        {
            Id(x => x.Id);

            LazyLoad();

            Map(x => x.StatusKey).Not.Nullable();

            Map(x => x.StatusName).Nullable();
        }
    }
}

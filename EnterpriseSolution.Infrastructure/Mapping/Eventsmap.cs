using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSolution.Core.Entities;
using FluentNHibernate.Mapping;

namespace EnterpriseSolution.Infrastructure.Mapping
{
    public class Eventsmap: ClassMap<Events>
    {
        public Eventsmap()
        {
            Id(x => x.Id);

            LazyLoad();

            Map(x => x.EventNumber);

            Map(x => x.EventCode);

            Map(x => x.EventDate);

            Map(x => x.Description);

            Map(x => x.AuthorizationStatusId);

            Map(x => x.MakerId);

            Map(x => x.AssetId);
        }

    }
}

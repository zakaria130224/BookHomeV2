using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSolution.Core.Entities;
using FluentNHibernate.Mapping;

namespace EnterpriseSolution.Infrastructure.Mapping
{
    class LinkageDetailsMap:ClassMap<LinkageDetails>
    {
        public LinkageDetailsMap()
        {
            Id(x => x.Id);
            LazyLoad();
            Map(x => x.AssetId);

            Map(x => x.ContactAmount);

            //Map(x => x.ContactRefference);

            //Map(x => x.ExpenseProcessing);

            Map(x => x.LinkedAmount);

            //Map(x => x.SupplierId);
        }
    }
}

using EnterpriseSolution.Core.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSolution.Infrastructure.Mapping
{
    public class ErrorLogMap : ClassMap<ErrorLog>
    {
        public ErrorLogMap()
        {
            Id(x => x.Id);

            LazyLoad();

            Map(x => x.Operations).Nullable();

            Map(x => x.ErrorMessage).Nullable();

            Map(x => x.OccuredOn).Nullable();
        }
    }
}

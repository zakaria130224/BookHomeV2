using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSolution.Core.Entities;
using FluentNHibernate.Mapping;

namespace EnterpriseSolution.Infrastructure.Mapping
{
    public class AuthorizationStatusMap:ClassMap<AuthorizationStatus>
    {
        public AuthorizationStatusMap()
        {
            Id(x => x.Id);

            LazyLoad();

            Map(x => x.StatusName);
        }
     
    }
}

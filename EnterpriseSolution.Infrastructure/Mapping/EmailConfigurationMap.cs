using EnterpriseSolution.Core.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSolution.Infrastructure.Mapping
{
    public class EmailConfigurationMap : ClassMap<EmailConfiguration>
    {
        public EmailConfigurationMap()
        {
            Id(x => x.Id);

            LazyLoad();

            Map(x => x.SmtpServer).Not.Nullable();

            Map(x => x.SmtpPort).Not.Nullable();

            Map(x => x.FromAddress).Nullable();

            Map(x => x.NetworkUserEmail).Nullable();

            Map(x => x.NetworkUserPass).Nullable();
        }
    }
}

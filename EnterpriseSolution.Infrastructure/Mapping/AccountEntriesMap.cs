using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSolution.Core.Entities;
using FluentNHibernate.Mapping;

namespace EnterpriseSolution.Infrastructure.Mapping
{
    class AccountEntriesMap:ClassMap<AccountEntries>
    {
        public AccountEntriesMap()
        {
            Id(x => x.Id);
            LazyLoad();
            Map(x => x.Account);
            Map(x => x.AccountDescription);
            Map(x => x.AmountCcy);
            Map(x => x.AmountTag);
            Map(x => x.Branch);
            Map(x => x.Date);
            Map(x => x.DrCr);
            Map(x => x.EventId);
            Map(x => x.ForeignCurrencyAmount);
            Map(x => x.LocalCurencyAmmount);
            Map(x => x.Rate);
            Map(x => x.TXNCODE);
            Map(x => x.ValueDate);
        }
    }
}

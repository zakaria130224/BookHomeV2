using EnterpriseSolution.Core.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSolution.Infrastructure.Mapping
{
    public class PaymentJournalMap : ClassMap<PaymentJournal>
    {
        public PaymentJournalMap()
        {
            Id(x => x.Id);

            LazyLoad();

            Map(x => x.BranchId).Not.Nullable();

            Map(x => x.PaymentDate).Not.Nullable();

            Map(x => x.ReferenceNumber).Not.Nullable();

            Map(x => x.PaymentType).Not.Nullable();

            Map(x => x.GlCode).Not.Nullable();

            Map(x => x.Description).Nullable();

            Map(x => x.Debit).Not.Nullable();

            Map(x => x.Credit).Not.Nullable();

            Map(x => x.IsReversed).Not.Nullable();
        }
    }
}

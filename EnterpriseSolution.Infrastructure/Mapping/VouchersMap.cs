using EnterpriseSolution.Core.Entities;
using FluentNHibernate.Mapping;

namespace EnterpriseSolution.Infrastructure.Mapping
{
    public class VouchersMap : ClassMap<Vouchers>
    {
        public VouchersMap()
        {
            Id(x => x.Id);

            LazyLoad();

            Map(x => x.PaymentStatus).Not.Nullable();

            Map(x => x.ReferenceNumber).Not.Nullable();

            Map(x => x.InvoiceNumber).Not.Nullable();

            Map(x => x.SupplierId).Not.Nullable();

            Map(x => x.ItemDescription).Nullable();

            Map(x => x.Quantity).Not.Nullable();

            Map(x => x.BillAmount).Not.Nullable();

            Map(x => x.SecurityMoney).Nullable();

            Map(x => x.VatRate).Not.Nullable();

            Map(x => x.AitRate).Not.Nullable();

            Map(x => x.NetPayableAmount).Nullable();

            Map(x => x.WorkOrder).Not.Nullable();

            Map(x => x.Invoiced).Not.Nullable();

            Map(x => x.ApprovedNote).Nullable();

            Map(x => x.IsActive).Not.Nullable();

            Map(x => x.CreatedBy).Not.Nullable();

            Map(x => x.CreatedOn).Not.Nullable();

            Map(x => x.LastModifiedBy).Nullable();

            Map(x => x.LastModifiedOn).Nullable();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EnterpriseSolution.Core.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;
//using EnterpriseSolution.Core.Entities.Views;

namespace EnterpriseSolution.Infrastructure.EnterpriseDbContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
           : base("name=DatabaseContext")
        {
        }
        
        public DbSet<Branches> Branches { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UserRolePermissions> UserRolePermissions { get; set; }
        public DbSet<Status> Status { get; set; }
        //public DbSet<AuthorizationStatus> AuthorizationStatus { get; set; }
        public DbSet<Prefixes> Prefixes { get; set; }
        //public DbSet<Currency> Currency { get; set; }
        //public DbSet<GlTypes> GlTypes { get; set; }
        //public DbSet<SupplierType> SupplierType { get; set; }
        //public DbSet<Suppliers> Suppliers { get; set; }
        //public DbSet<SupplierAccount> SupplierAccount { get; set; }
        //public DbSet<SupplierTradeRef> SupplierTradeRef { get; set; }
        //public DbSet<VoucherStatus> VoucherStatus { get; set; }
        //public DbSet<Vouchers> Vouchers { get; set; }
        //public DbSet<PaymentJournal> PaymentJournal { get; set; }
        //public DbSet<Locations> Locations { get; set; }
        //public DbSet<Events> Events { get; set; }
        //public DbSet<LinkageDetails> LinkageDetails { get; set; }
        //public DbSet<Consignments> Consignments { get; set; }
        //public DbSet<DepreciationStaging> DepreciationStaging { get; set; }
        //public DbSet<DepreciationConfig> DepreciationConfig { get; set; }
        //public DbSet<GlTypeStaging> GlTypeStaging { get; set; }
        //public DbSet<GlAccountsStaging> GlAccountsStaging { get; set; }
        //public DbSet<LocationPosition> LocationPosition { get; set; }
        //public DbSet<Department> Department { get; set; }
        //public DbSet<Screens> Screens { get; set; }
        //public DbSet<Modules> Modules { get; set; }
        //public DbSet<GlActionMatrix> GlActionMatrix { get; set; }
        //public DbSet<DepreciationSummary> DepreciationSummary { get; set; }
        //public DbSet<GlAccounts> GLManagement { get; set; }
        //public DbSet<ScreenFieldsMap> ScreenFieldsMap { get; set; }
        //public DbSet<ScreenFieldAccountMap> ScreenFieldAccountMap { get; set; }
        //public DbSet<ConsignmentsLots> ConsignmentsLots { get; set; }
        //public DbSet<BankPayments> BankPayments { get; set; }
        //public DbSet<ReleaseSecurityMoney> ReleaseSecurityMoney { get; set; }
        //public DbSet<IncomeTypes> IncomeTypes { get; set; }
        //public DbSet<Sales> Sales { get; set; }
        //public DbSet<WorkOrders> WorkOrders { get; set; }
        //public DbSet<OtherSupplierPayments> OtherSupplierPayment { get; set; }
        //public DbSet<OtherSalesPayments> OtherSalesPayment { get; set; }
        //public DbSet<ExpenditureCategory> ExpenditureCategory { get; set; }
        //public DbSet<SingleEntries> SingleEntries { get; set; }
        //public DbSet<LoanTypes> LoanTypes { get; set; }
        //public DbSet<LoanStatus> LoanStatus { get; set; }
        ////Added By: Zakaria
        //public DbSet<Loans> Loans { get; set; }
        ////Added By: Zakaria on 04.11.18
        //public DbSet<LoanInstallments> LoanInstallments { get; set; }
        //Database Views | added by milon on 03.11.2018
        //Added by Abbir on 12.11.2018
        //public DbSet<DepreciationDetails> DepreciationDetails { get; set; }
        ////Added By Abbir on 14.11.2018
        //public DbSet<DepreciationAccountMapping> DepreciationAccountMapping { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var conventions = new List<PluralizingTableNameConvention>().ToArray();
            modelBuilder.Conventions.Remove(conventions);
            base.OnModelCreating(modelBuilder);
        }
    }
}


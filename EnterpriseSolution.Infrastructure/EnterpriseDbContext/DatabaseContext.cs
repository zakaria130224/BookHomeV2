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
        public DbSet<BookCategory> BookCategory { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Book { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var conventions = new List<PluralizingTableNameConvention>().ToArray();
            modelBuilder.Conventions.Remove(conventions);
            base.OnModelCreating(modelBuilder);
        }
    }
}


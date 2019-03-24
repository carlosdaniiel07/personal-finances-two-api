using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

using personal_finances_two_api.Models;

namespace personal_finances_two_api.Repositories
{
    public class AppDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Movement> Movements { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        public AppDbContext() : base("ConnectionString")
        {
            Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
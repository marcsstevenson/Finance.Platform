using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Finance.Logic.Counting;
using Finance.Logic.Crm;
using Finance.Logic.Deals;
using Finance.Logic.FinanceCompanies;
using Finance.Logic.Indentity;
using Finance.Logic.Internal;
using Generic.Repository.EfCore.Annotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Finance.Repository.EfCore.Context
{
    public class FinanceDbContext : IdentityDbContext<PartyIdentityUser>
    {
        public const string ConnectionStringName = "DefaultConnection";

        //public FinanceDbContext() : base()
        //{

        //}

        public static FinanceDbContext Create()
        {
            return new FinanceDbContext();
        }
        
        public FinanceDbContext() :
            base(ConnectionStringName, false)
        {
            SetOptions();
        }

        private void SetOptions()
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = true;
            this.Configuration.AutoDetectChangesEnabled = true;
            this.Configuration.ValidateOnSaveEnabled = true;

            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 180;
        }

        public DbSet<Customer> Customer { get; set; }
        
        public DbSet<Dealership> Dealership { get; set; }
        
        public DbSet<Deal> Deal { get; set; }
        
        public DbSet<CounterStore> CounterStore { get; set; }
        
        public DbSet<FinanceCompany> FinanceCompany { get; set; }
        
        public DbSet<StaffMember> StaffMember { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Add to this as new classes are added to the EF repository
            //this.OnModelCreatingHtmlCollection(modelBuilder);
            this.OnModelCreatingDeals(modelBuilder);
            this.OnModelCreatingCustomer(modelBuilder);
            Precision.ConfigureModelBuilder(modelBuilder);
        }

        protected void OnModelCreatingDeals(DbModelBuilder modelBuilder)
        {
            //Set the precision on the properties that we want to be generated as decimal(18,2)

            modelBuilder.Entity<Deal>().Property(xx => xx.Rate).HasPrecision(18, 2);
            modelBuilder.Entity<Deal>().Property(xx => xx.FinanceVolume).HasPrecision(18, 2);
            modelBuilder.Entity<Deal>().Property(xx => xx.Commission).HasPrecision(18, 2);
            modelBuilder.Entity<Deal>().Property(xx => xx.DocumentationFee).HasPrecision(18, 2);
            modelBuilder.Entity<Deal>().Property(xx => xx.PaymentProtectionInsurance).HasPrecision(18, 2);
            modelBuilder.Entity<Deal>().Property(xx => xx.GuaranteedAssetProtection).HasPrecision(18, 2);

            modelBuilder.Entity<Deal>().Property(xx => xx.MechanicalBreakDownInsurance).HasPrecision(18, 2);
            modelBuilder.Entity<Deal>().Property(xx => xx.OtherInsurance).HasPrecision(18, 2);
            modelBuilder.Entity<Deal>().Property(xx => xx.DealershipCommission).HasPrecision(18, 2);
            modelBuilder.Entity<Deal>().Property(xx => xx.DealershipClawbackNotes).HasPrecision(18, 2);
            
            base.OnModelCreating(modelBuilder);
        }
        protected void OnModelCreatingCustomer(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Deal>()
                //Construct the relationship between Customer and Deal
                .HasRequired(i => i.Customer)
                .WithMany(s => s.Deals)
                .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }
    }
}

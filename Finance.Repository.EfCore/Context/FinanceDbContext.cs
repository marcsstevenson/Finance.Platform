using Finance.Logic.Crm;
using Finance.Logic.Deals;
using Finance.Logic.FinanceCompanies;
using Finance.Logic.Internal;
using Finance.Repository.EfCore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Finance.Repository.EfCore.Context
{
    public class FinanceDbContext : IdentityDbContext<ApplicationUser>
    {
        //public FinanceDbContext() : base()
        //{
            
        //}

        public FinanceDbContext(DbContextOptions<FinanceDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }
        
        public DbSet<Dealership> Dealership { get; set; }
        
        public DbSet<Deal> Deal { get; set; }
        
        public DbSet<FinanceCompany> FinanceCompany { get; set; }
        
        public DbSet<StaffMember> StaffMember { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}

using System.Data.Entity.Migrations;
using Finance.Repository.EfCore.Context;

namespace Finance.Repository.EfCore.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<FinanceDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    }
}

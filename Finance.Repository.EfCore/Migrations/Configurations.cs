using System.Data.Entity.Migrations;
using Finance.Repository.Ef.Context;

namespace Finance.Repository.Ef.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<FinanceDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    }
}

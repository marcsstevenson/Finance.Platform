using Finance.Repository.EfCore.Context;
using Finance.Repository.EfCore.Migrations;
using FWS.Generic.Framework.Repository.EF.Helpers;

namespace Finance.Repository.EfCore.Helpers
{
    public class FinanceMigrationManager : DbMigrationManager<Configuration, FinanceDbContext>
    {
    }
}

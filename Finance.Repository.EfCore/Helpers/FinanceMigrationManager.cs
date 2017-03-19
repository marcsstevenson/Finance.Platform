using Finance.Repository.Ef.Context;
using Finance.Repository.Ef.Migrations;
using FWS.Generic.Framework.Repository.EF.Helpers;

namespace Finance.Repository.Ef.Helpers
{
    public class FinanceMigrationManager : DbMigrationManager<Configuration, FinanceDbContext>
    {
    }
}

using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Web.Http;
using Finance.Repository.EfCore.Helpers;

namespace Finance.Api.Api
{
    [Authorize] 
    public class MigrationsController : ApiController
    {
        private DbMigrator _dbMigrator;

        public DbMigrator DbMigrator => _dbMigrator ?? (_dbMigrator = FinanceMigrationManager.GetMigrator());

        [HttpGet]
        [Route(nameof(GetPendingMigrations))]
        public IEnumerable<string> GetPendingMigrations()
        {
            return DbMigrator.GetPendingMigrations();
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Finance.Repository.Ef.Helpers;

namespace Finance.Api.Api.Admin
{
    [Authorize]
    [RoutePrefix("api/Account")]
    public class DatabaseController : ApiController
    {
        // GET api/Account/Test
        [HttpGet]
        [Route("RunUpdates")]
        public int RunUpdates()
        {
            var dbMigrator = FinanceMigrationManager.GetMigrator();
            dbMigrator.Configuration.CommandTimeout = 180;
            var pendingMigrations = dbMigrator.GetPendingMigrations().ToList();

            //Update the database if we need to
            if (pendingMigrations.Count > 0)
                dbMigrator.Update();

            return pendingMigrations.Count;
        }
    }
}

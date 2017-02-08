namespace Finance.Repository.EfCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinanceCompanyAccountManager : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FinanceCompanies", "AccountManager", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FinanceCompanies", "AccountManager");
        }
    }
}

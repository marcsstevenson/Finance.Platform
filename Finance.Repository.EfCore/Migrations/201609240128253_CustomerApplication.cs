namespace Finance.Repository.EfCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerApplication : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CustomerAppliationFinancials", newName: "CustomerApplicationFinancials");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.CustomerApplicationFinancials", newName: "CustomerAppliationFinancials");
        }
    }
}

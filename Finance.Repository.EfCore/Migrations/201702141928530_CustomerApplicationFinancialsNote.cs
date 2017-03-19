namespace Finance.Repository.Ef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerApplicationFinancialsNote : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerApplicationFinancials", "Note", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerApplicationFinancials", "Note");
        }
    }
}

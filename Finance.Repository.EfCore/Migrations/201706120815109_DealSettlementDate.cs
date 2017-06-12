namespace Finance.Repository.Ef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DealSettlementDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Deals", "SettlementDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Deals", "SettlementDate");
        }
    }
}

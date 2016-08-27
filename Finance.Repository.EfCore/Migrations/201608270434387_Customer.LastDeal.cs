namespace Finance.Repository.EfCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerLastDeal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "LastDeal_Id", c => c.Guid());
            CreateIndex("dbo.Customers", "LastDeal_Id");
            AddForeignKey("dbo.Customers", "LastDeal_Id", "dbo.Deals", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "LastDeal_Id", "dbo.Deals");
            DropIndex("dbo.Customers", new[] { "LastDeal_Id" });
            DropColumn("dbo.Customers", "LastDeal_Id");
        }
    }
}

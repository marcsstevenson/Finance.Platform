namespace Finance.Repository.EfCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CounterStore : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CounterStores",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CustomerCounter = c.Int(nullable: false),
                        DealCounter = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            Sql("INSERT INTO [dbo].[CounterStores] ([Id],[CustomerCounter],[DealCounter],[DateCreated],[DateModified]) VALUES (newId() ,20,20,getdate(),getdate())");
        }
        
        public override void Down()
        {
            DropTable("dbo.CounterStores");
        }
    }
}

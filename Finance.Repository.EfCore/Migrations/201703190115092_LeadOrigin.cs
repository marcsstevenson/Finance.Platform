namespace Finance.Repository.Ef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LeadOrigin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LeadOrigins",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        IsDefault = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LeadOrigins");
        }
    }
}

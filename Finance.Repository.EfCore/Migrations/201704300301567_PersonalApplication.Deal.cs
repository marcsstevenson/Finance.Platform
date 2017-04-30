namespace Finance.Repository.Ef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonalApplicationDeal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PersonalApplications", "Deal_Id", c => c.Guid());
            CreateIndex("dbo.PersonalApplications", "Deal_Id");
            AddForeignKey("dbo.PersonalApplications", "Deal_Id", "dbo.Deals", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonalApplications", "Deal_Id", "dbo.Deals");
            DropIndex("dbo.PersonalApplications", new[] { "Deal_Id" });
            DropColumn("dbo.PersonalApplications", "Deal_Id");
        }
    }
}

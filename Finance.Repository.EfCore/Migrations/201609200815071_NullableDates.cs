namespace Finance.Repository.EfCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableDates : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "DateOfBirth", c => c.DateTime());
            AlterColumn("dbo.CustomerApplications", "DateSigned", c => c.DateTime());
            AlterColumn("dbo.PersonalEntities", "DateOfBirth", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PersonalEntities", "DateOfBirth", c => c.DateTime(nullable: false));
            AlterColumn("dbo.CustomerApplications", "DateSigned", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "DateOfBirth", c => c.DateTime(nullable: false));
        }
    }
}

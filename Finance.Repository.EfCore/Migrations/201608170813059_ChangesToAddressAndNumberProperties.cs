namespace Finance.Repository.Ef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesToAddressAndNumberProperties : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Number", c => c.String(nullable: false));
            AlterColumn("dbo.Deals", "Number", c => c.String(nullable: false));
            DropColumn("dbo.CustomerStreetAddresses", "ContactPhoneNumber");
            DropColumn("dbo.DealershipStreetAddresses", "ContactPhoneNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DealershipStreetAddresses", "ContactPhoneNumber", c => c.String());
            AddColumn("dbo.CustomerStreetAddresses", "ContactPhoneNumber", c => c.String());
            AlterColumn("dbo.Deals", "Number", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "Number", c => c.Int(nullable: false));
        }
    }
}

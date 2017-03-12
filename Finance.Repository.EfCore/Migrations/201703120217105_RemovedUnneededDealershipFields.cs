namespace Finance.Repository.EfCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedUnneededDealershipFields : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Dealerships", "PhoneCountry");
            DropColumn("dbo.Dealerships", "PhoneArea");
            DropColumn("dbo.Dealerships", "CellCountry");
            DropColumn("dbo.Dealerships", "CellArea");
            DropColumn("dbo.Dealerships", "FaxCountry");
            DropColumn("dbo.Dealerships", "FaxArea");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Dealerships", "FaxArea", c => c.String());
            AddColumn("dbo.Dealerships", "FaxCountry", c => c.String());
            AddColumn("dbo.Dealerships", "CellArea", c => c.String());
            AddColumn("dbo.Dealerships", "CellCountry", c => c.String());
            AddColumn("dbo.Dealerships", "PhoneArea", c => c.String());
            AddColumn("dbo.Dealerships", "PhoneCountry", c => c.String());
        }
    }
}

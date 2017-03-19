namespace Finance.Repository.Ef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsuranceOtherSplit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Deals", "Insurance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Deals", "Other", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Deals", "OtherNote", c => c.String());
            DropColumn("dbo.Deals", "OtherInsurance");
            DropColumn("dbo.Deals", "OtherInsuranceNote");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Deals", "OtherInsuranceNote", c => c.String());
            AddColumn("dbo.Deals", "OtherInsurance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Deals", "OtherNote");
            DropColumn("dbo.Deals", "Other");
            DropColumn("dbo.Deals", "Insurance");
        }
    }
}

namespace Finance.Repository.EfCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinanceCompanyAccountManagerP2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountManagers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(),
                        Gender = c.Int(),
                        Email = c.String(),
                        MobileNumber = c.String(),
                        PhoneNumber = c.String(),
                        FaxNumber = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "MiddleName", c => c.String());
            AddColumn("dbo.Customers", "PreferredName", c => c.String());
            AddColumn("dbo.Customers", "MobileNumber", c => c.String());
            AddColumn("dbo.Customers", "WorkNumber", c => c.String());
            AddColumn("dbo.Deals", "LoanNumber", c => c.Int(nullable: false));
            AddColumn("dbo.FinanceCompanies", "TierFunder", c => c.Int(nullable: false));
            AddColumn("dbo.FinanceCompanies", "AccountManager_Id", c => c.Guid());
            AddColumn("dbo.Dealerships", "MobileNumber", c => c.String());
            AddColumn("dbo.PersonalEntities", "MobileNumber", c => c.String());
            CreateIndex("dbo.FinanceCompanies", "AccountManager_Id");
            AddForeignKey("dbo.FinanceCompanies", "AccountManager_Id", "dbo.AccountManagers", "Id");
            DropColumn("dbo.Customers", "CellNumber");
            DropColumn("dbo.Deals", "CashManagerReference");
            DropColumn("dbo.FinanceCompanies", "AccountManager");
            DropColumn("dbo.Dealerships", "CellNumber");
            DropColumn("dbo.PersonalEntities", "CellNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PersonalEntities", "CellNumber", c => c.String());
            AddColumn("dbo.Dealerships", "CellNumber", c => c.String());
            AddColumn("dbo.FinanceCompanies", "AccountManager", c => c.String());
            AddColumn("dbo.Deals", "CashManagerReference", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "CellNumber", c => c.String());
            DropForeignKey("dbo.FinanceCompanies", "AccountManager_Id", "dbo.AccountManagers");
            DropIndex("dbo.FinanceCompanies", new[] { "AccountManager_Id" });
            DropColumn("dbo.PersonalEntities", "MobileNumber");
            DropColumn("dbo.Dealerships", "MobileNumber");
            DropColumn("dbo.FinanceCompanies", "AccountManager_Id");
            DropColumn("dbo.FinanceCompanies", "TierFunder");
            DropColumn("dbo.Deals", "LoanNumber");
            DropColumn("dbo.Customers", "WorkNumber");
            DropColumn("dbo.Customers", "MobileNumber");
            DropColumn("dbo.Customers", "PreferredName");
            DropColumn("dbo.Customers", "MiddleName");
            DropTable("dbo.AccountManagers");
        }
    }
}

namespace Finance.Repository.EfCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Gender = c.Int(),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        DriversLicenceNumber = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Number = c.Int(nullable: false),
                        Email = c.String(),
                        PhoneCountry = c.String(),
                        PhoneArea = c.String(),
                        PhoneNumber = c.String(),
                        CellCountry = c.String(),
                        CellArea = c.String(),
                        CellNumber = c.String(),
                        FaxCountry = c.String(),
                        FaxArea = c.String(),
                        FaxNumber = c.String(),
                        SkypeName = c.String(),
                        Website = c.String(),
                        BankingCompany = c.String(),
                        BankAccountName = c.String(),
                        BankBranchName = c.String(),
                        BankAccountNumber = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomerNotes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Note = c.String(nullable: false),
                        EnteredBy = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        Customer_Id = c.Guid(nullable: false),
                        Dealership_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Dealerships", t => t.Dealership_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.Dealership_Id);
            
            CreateTable(
                "dbo.CustomerStreetAddresses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Region = c.String(),
                        Name = c.String(),
                        ContactPhoneNumber = c.String(),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                        AddressLine3 = c.String(),
                        Postcode = c.String(),
                        City = c.String(),
                        IsDefault = c.Boolean(nullable: false),
                        Type = c.String(),
                        OtherInformation = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        Customer_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id, cascadeDelete: true)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.Deals",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Number = c.Int(nullable: false),
                        CashManagerReference = c.Int(nullable: false),
                        DealStatus = c.Int(nullable: false),
                        SecurityDescription = c.String(),
                        TermInMonths = c.Int(nullable: false),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FinanceVolume = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Commission = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DocumentationFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentProtectionInsurance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GuaranteedAssetProtection = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MechanicalBreakDownInsurance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OtherInsurance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OtherInsuranceNote = c.String(),
                        DealershipCommission = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DealershipClawbackNotes = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        AssignedTo_Id = c.Guid(),
                        Customer_Id = c.Guid(nullable: false),
                        FinanceCompany_Id = c.Guid(),
                        Source_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StaffMembers", t => t.AssignedTo_Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id, cascadeDelete: true)
                .ForeignKey("dbo.FinanceCompanies", t => t.FinanceCompany_Id)
                .ForeignKey("dbo.Dealerships", t => t.Source_Id)
                .Index(t => t.AssignedTo_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.FinanceCompany_Id)
                .Index(t => t.Source_Id);
            
            CreateTable(
                "dbo.StaffMembers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DealNotes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Note = c.String(nullable: false),
                        EnteredBy = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        Deal_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Deals", t => t.Deal_Id, cascadeDelete: true)
                .Index(t => t.Deal_Id);
            
            CreateTable(
                "dbo.FinanceCompanies",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Dealerships",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IsEnabled = c.Boolean(nullable: false),
                        Name = c.String(nullable: false),
                        ContactName = c.String(),
                        Website = c.String(),
                        Email = c.String(),
                        PhoneCountry = c.String(),
                        PhoneArea = c.String(),
                        PhoneNumber = c.String(),
                        CellCountry = c.String(),
                        CellArea = c.String(),
                        CellNumber = c.String(),
                        FaxCountry = c.String(),
                        FaxArea = c.String(),
                        FaxNumber = c.String(),
                        BankingCompany = c.String(),
                        BankAccountName = c.String(),
                        BankBranchName = c.String(),
                        BankAccountNumber = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DealershipStreetAddresses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Region = c.String(),
                        Name = c.String(),
                        ContactPhoneNumber = c.String(),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                        AddressLine3 = c.String(),
                        Postcode = c.String(),
                        City = c.String(),
                        IsDefault = c.Boolean(nullable: false),
                        Type = c.String(),
                        OtherInformation = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        Dealership_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dealerships", t => t.Dealership_Id, cascadeDelete: true)
                .Index(t => t.Dealership_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Deals", "Source_Id", "dbo.Dealerships");
            DropForeignKey("dbo.DealershipStreetAddresses", "Dealership_Id", "dbo.Dealerships");
            DropForeignKey("dbo.CustomerNotes", "Dealership_Id", "dbo.Dealerships");
            DropForeignKey("dbo.Deals", "FinanceCompany_Id", "dbo.FinanceCompanies");
            DropForeignKey("dbo.DealNotes", "Deal_Id", "dbo.Deals");
            DropForeignKey("dbo.Deals", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Deals", "AssignedTo_Id", "dbo.StaffMembers");
            DropForeignKey("dbo.CustomerStreetAddresses", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.CustomerNotes", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.DealershipStreetAddresses", new[] { "Dealership_Id" });
            DropIndex("dbo.DealNotes", new[] { "Deal_Id" });
            DropIndex("dbo.Deals", new[] { "Source_Id" });
            DropIndex("dbo.Deals", new[] { "FinanceCompany_Id" });
            DropIndex("dbo.Deals", new[] { "Customer_Id" });
            DropIndex("dbo.Deals", new[] { "AssignedTo_Id" });
            DropIndex("dbo.CustomerStreetAddresses", new[] { "Customer_Id" });
            DropIndex("dbo.CustomerNotes", new[] { "Dealership_Id" });
            DropIndex("dbo.CustomerNotes", new[] { "Customer_Id" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.DealershipStreetAddresses");
            DropTable("dbo.Dealerships");
            DropTable("dbo.FinanceCompanies");
            DropTable("dbo.DealNotes");
            DropTable("dbo.StaffMembers");
            DropTable("dbo.Deals");
            DropTable("dbo.CustomerStreetAddresses");
            DropTable("dbo.CustomerNotes");
            DropTable("dbo.Customers");
        }
    }
}

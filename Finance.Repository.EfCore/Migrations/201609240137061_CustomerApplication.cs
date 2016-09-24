using Finance.Repository.EfCore.Migrations.Sql;

namespace Finance.Repository.EfCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerApplication : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppliationFinancialOptions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AppliationFinancialType = c.Int(nullable: false),
                        Name = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            //Asset
            foreach (var sql in AppliationFinancialOptions.Add())
                Sql(sql);

            CreateTable(
                "dbo.CustomerApplications",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        VehicleUsePersonal = c.Boolean(nullable: false),
                        VehicleUseBusiness = c.Boolean(nullable: false),
                        VehicleUseSoleTrader = c.Boolean(nullable: false),
                        VehicleUseLimitedLiability = c.Boolean(nullable: false),
                        DateSigned = c.DateTime(),
                        Number = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        Applicant_Id = c.Guid(nullable: false),
                        Spouce_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonalEntities", t => t.Applicant_Id, cascadeDelete: true)
                .ForeignKey("dbo.PersonalEntities", t => t.Spouce_Id)
                .Index(t => t.Applicant_Id)
                .Index(t => t.Spouce_Id);
            
            CreateTable(
                "dbo.PersonalEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        MiddleNames = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(),
                        Gender = c.Int(),
                        MaritalStatus = c.Int(nullable: false),
                        OriginCountry = c.String(),
                        DiversLicenceStatus = c.Int(nullable: false),
                        OverseasDiversLicence = c.String(),
                        LicenceNumberSa = c.String(),
                        LicenceNumberSb = c.String(),
                        CellNumber = c.String(),
                        PhoneNumber = c.String(),
                        FaxNumber = c.String(),
                        CellNumberBusiness = c.String(),
                        PhoneNumberBusiness = c.String(),
                        FaxNumberBusiness = c.String(),
                        OccupationEmployer = c.String(),
                        Occupation = c.String(),
                        OccupationAddressStreet = c.String(),
                        OccupationAddressSuburb = c.String(),
                        OccupationAddressPostcode = c.String(),
                        OccupationAddressCity = c.String(),
                        OccupationDurationInMonths = c.Int(),
                        PreviousEmployer = c.String(),
                        PreviousOccupation = c.String(),
                        PreviousOccupationDurationInMonths = c.Int(),
                        CurrentAddressArrangement = c.Int(nullable: false),
                        CurrentAddressArrangementOther = c.String(),
                        NearestRelativeName = c.String(),
                        NearestRelativeRelationship = c.String(),
                        NearestRelativePhoneNumber = c.String(),
                        Reference1Name = c.String(),
                        Reference2Name = c.String(),
                        Bankers = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        CurrentAddress_Id = c.Guid(),
                        NearestRelativeAddress_Id = c.Guid(),
                        PreviousAddress_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StreetAddresses", t => t.CurrentAddress_Id)
                .ForeignKey("dbo.StreetAddresses", t => t.NearestRelativeAddress_Id)
                .ForeignKey("dbo.StreetAddresses", t => t.PreviousAddress_Id)
                .Index(t => t.CurrentAddress_Id)
                .Index(t => t.NearestRelativeAddress_Id)
                .Index(t => t.PreviousAddress_Id);
            
            CreateTable(
                "dbo.StreetAddresses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Region = c.String(),
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
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomerApplicationFinancials",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OptionName = c.String(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AppliationFinancialType = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        CustomerApplication_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerApplications", t => t.CustomerApplication_Id)
                .Index(t => t.CustomerApplication_Id);
            
            CreateTable(
                "dbo.CustomerApplicationNotes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Note = c.String(nullable: false),
                        EnteredBy = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        CustomerApplication_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerApplications", t => t.CustomerApplication_Id, cascadeDelete: true)
                .Index(t => t.CustomerApplication_Id);
            
            AddColumn("dbo.CounterStores", "CustomerApplication", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "DateOfBirth", c => c.DateTime());
            DropColumn("dbo.Customers", "PhoneCountry");
            DropColumn("dbo.Customers", "PhoneArea");
            DropColumn("dbo.Customers", "CellCountry");
            DropColumn("dbo.Customers", "CellArea");
            DropColumn("dbo.Customers", "FaxCountry");
            DropColumn("dbo.Customers", "FaxArea");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "FaxArea", c => c.String());
            AddColumn("dbo.Customers", "FaxCountry", c => c.String());
            AddColumn("dbo.Customers", "CellArea", c => c.String());
            AddColumn("dbo.Customers", "CellCountry", c => c.String());
            AddColumn("dbo.Customers", "PhoneArea", c => c.String());
            AddColumn("dbo.Customers", "PhoneCountry", c => c.String());
            DropForeignKey("dbo.CustomerApplications", "Spouce_Id", "dbo.PersonalEntities");
            DropForeignKey("dbo.CustomerApplicationNotes", "CustomerApplication_Id", "dbo.CustomerApplications");
            DropForeignKey("dbo.CustomerApplicationFinancials", "CustomerApplication_Id", "dbo.CustomerApplications");
            DropForeignKey("dbo.CustomerApplications", "Applicant_Id", "dbo.PersonalEntities");
            DropForeignKey("dbo.PersonalEntities", "PreviousAddress_Id", "dbo.StreetAddresses");
            DropForeignKey("dbo.PersonalEntities", "NearestRelativeAddress_Id", "dbo.StreetAddresses");
            DropForeignKey("dbo.PersonalEntities", "CurrentAddress_Id", "dbo.StreetAddresses");
            DropIndex("dbo.CustomerApplicationNotes", new[] { "CustomerApplication_Id" });
            DropIndex("dbo.CustomerApplicationFinancials", new[] { "CustomerApplication_Id" });
            DropIndex("dbo.PersonalEntities", new[] { "PreviousAddress_Id" });
            DropIndex("dbo.PersonalEntities", new[] { "NearestRelativeAddress_Id" });
            DropIndex("dbo.PersonalEntities", new[] { "CurrentAddress_Id" });
            DropIndex("dbo.CustomerApplications", new[] { "Spouce_Id" });
            DropIndex("dbo.CustomerApplications", new[] { "Applicant_Id" });
            AlterColumn("dbo.Customers", "DateOfBirth", c => c.DateTime(nullable: false));
            DropColumn("dbo.CounterStores", "CustomerApplication");
            DropTable("dbo.CustomerApplicationNotes");
            DropTable("dbo.CustomerApplicationFinancials");
            DropTable("dbo.StreetAddresses");
            DropTable("dbo.PersonalEntities");
            DropTable("dbo.CustomerApplications");
            DropTable("dbo.AppliationFinancialOptions");
        }
    }
}

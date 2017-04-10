namespace Finance.Repository.Ef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonalApplication : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PersonalApplications",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SchemaVersion = c.String(),
                        JsonData = c.String(),
                        Status = c.Int(nullable: false),
                        FirstName = c.String(),
                        PreferredName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        MobilePhoneNumber = c.String(),
                        HomePhoneNumber = c.String(),
                        LicenceNumberSa = c.String(),
                        PersonalEmail = c.String(),
                        BusinessEmail = c.String(),
                        Number = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        Customer_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.PersonalApplicationNotes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Note = c.String(nullable: false),
                        EnteredBy = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        PersonalApplication_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonalApplications", t => t.PersonalApplication_Id, cascadeDelete: true)
                .Index(t => t.PersonalApplication_Id);
            
            DropColumn("dbo.PersonalEntities", "CellNumberBusiness");
            DropColumn("dbo.PersonalEntities", "PhoneNumberBusiness");
            DropColumn("dbo.PersonalEntities", "FaxNumberBusiness");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PersonalEntities", "FaxNumberBusiness", c => c.String());
            AddColumn("dbo.PersonalEntities", "PhoneNumberBusiness", c => c.String());
            AddColumn("dbo.PersonalEntities", "CellNumberBusiness", c => c.String());
            DropForeignKey("dbo.PersonalApplicationNotes", "PersonalApplication_Id", "dbo.PersonalApplications");
            DropForeignKey("dbo.PersonalApplications", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.PersonalApplicationNotes", new[] { "PersonalApplication_Id" });
            DropIndex("dbo.PersonalApplications", new[] { "Customer_Id" });
            DropTable("dbo.PersonalApplicationNotes");
            DropTable("dbo.PersonalApplications");
        }
    }
}

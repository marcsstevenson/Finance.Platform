namespace Finance.Repository.Ef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonalApplicationForms : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PersonalApplicationForms",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SchemaVersion = c.String(nullable: false),
                        JsonData = c.String(nullable: false),
                        FormType = c.String(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        PersonalApplication_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonalApplications", t => t.PersonalApplication_Id, cascadeDelete: true)
                .Index(t => t.PersonalApplication_Id);
            
            AlterColumn("dbo.PersonalApplications", "SchemaVersion", c => c.String(nullable: false));
            AlterColumn("dbo.PersonalApplications", "JsonData", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonalApplicationForms", "PersonalApplication_Id", "dbo.PersonalApplications");
            DropIndex("dbo.PersonalApplicationForms", new[] { "PersonalApplication_Id" });
            AlterColumn("dbo.PersonalApplications", "JsonData", c => c.String());
            AlterColumn("dbo.PersonalApplications", "SchemaVersion", c => c.String());
            DropTable("dbo.PersonalApplicationForms");
        }
    }
}

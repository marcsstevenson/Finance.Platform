namespace Finance.Repository.EfCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinanceCompanyChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FinanceCompanies", "AccountManager_Id", "dbo.AccountManagers");
            DropIndex("dbo.FinanceCompanies", new[] { "AccountManager_Id" });
            CreateTable(
                "dbo.FinanceCompanyNotes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Note = c.String(nullable: false),
                        EnteredBy = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        FinanceCompany_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FinanceCompanies", t => t.FinanceCompany_Id, cascadeDelete: true)
                .Index(t => t.FinanceCompany_Id);
            
            AddColumn("dbo.AccountManagers", "Note", c => c.String());
            AddColumn("dbo.AccountManagers", "FinanceCompany_Id", c => c.Guid(nullable: false));
            CreateIndex("dbo.AccountManagers", "FinanceCompany_Id");
            AddForeignKey("dbo.AccountManagers", "FinanceCompany_Id", "dbo.FinanceCompanies", "Id", cascadeDelete: true);
            DropColumn("dbo.FinanceCompanies", "AccountManager_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FinanceCompanies", "AccountManager_Id", c => c.Guid());
            DropForeignKey("dbo.FinanceCompanyNotes", "FinanceCompany_Id", "dbo.FinanceCompanies");
            DropForeignKey("dbo.AccountManagers", "FinanceCompany_Id", "dbo.FinanceCompanies");
            DropIndex("dbo.FinanceCompanyNotes", new[] { "FinanceCompany_Id" });
            DropIndex("dbo.AccountManagers", new[] { "FinanceCompany_Id" });
            DropColumn("dbo.AccountManagers", "FinanceCompany_Id");
            DropColumn("dbo.AccountManagers", "Note");
            DropTable("dbo.FinanceCompanyNotes");
            CreateIndex("dbo.FinanceCompanies", "AccountManager_Id");
            AddForeignKey("dbo.FinanceCompanies", "AccountManager_Id", "dbo.AccountManagers", "Id");
        }
    }
}

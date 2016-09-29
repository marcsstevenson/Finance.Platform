using System.Collections.Generic;

namespace Finance.Repository.EfCore.Migrations.Sql
{
    public static class AppliationFinancialOptions
    {

        public static List<string> Add()
        {
            var toAdd = new List<string>();

            //Asset
            toAdd.Add("INSERT INTO [dbo].[AppliationFinancialOptions] ([Id],[AppliationFinancialType],[Name],[DateCreated],[DateModified]) VALUES (newId() ,0,'Home',getdate(),getdate())");
            toAdd.Add("INSERT INTO [dbo].[AppliationFinancialOptions] ([Id],[AppliationFinancialType],[Name],[DateCreated],[DateModified]) VALUES (newId() ,0,'Property',getdate(),getdate())");
            toAdd.Add("INSERT INTO [dbo].[AppliationFinancialOptions] ([Id],[AppliationFinancialType],[Name],[DateCreated],[DateModified]) VALUES (newId() ,0,'Home/Contents',getdate(),getdate())");
            toAdd.Add("INSERT INTO [dbo].[AppliationFinancialOptions] ([Id],[AppliationFinancialType],[Name],[DateCreated],[DateModified]) VALUES (newId() ,0,'Car',getdate(),getdate())");
            toAdd.Add("INSERT INTO [dbo].[AppliationFinancialOptions] ([Id],[AppliationFinancialType],[Name],[DateCreated],[DateModified]) VALUES (newId() ,0,'Motorcycle',getdate(),getdate())");
            toAdd.Add("INSERT INTO [dbo].[AppliationFinancialOptions] ([Id],[AppliationFinancialType],[Name],[DateCreated],[DateModified]) VALUES (newId() ,0,'Boat',getdate(),getdate())");
            toAdd.Add("INSERT INTO [dbo].[AppliationFinancialOptions] ([Id],[AppliationFinancialType],[Name],[DateCreated],[DateModified]) VALUES (newId() ,0,'Bank',getdate(),getdate())");
            toAdd.Add("INSERT INTO [dbo].[AppliationFinancialOptions] ([Id],[AppliationFinancialType],[Name],[DateCreated],[DateModified]) VALUES (newId() ,0,'Investments',getdate(),getdate())");
            toAdd.Add("INSERT INTO [dbo].[AppliationFinancialOptions] ([Id],[AppliationFinancialType],[Name],[DateCreated],[DateModified]) VALUES (newId() ,0,'Kiwisaver',getdate(),getdate())");
            toAdd.Add("INSERT INTO [dbo].[AppliationFinancialOptions] ([Id],[AppliationFinancialType],[Name],[DateCreated],[DateModified]) VALUES (newId() ,0,'Other',getdate(),getdate())");
            toAdd.Add("INSERT INTO [dbo].[AppliationFinancialOptions] ([Id],[AppliationFinancialType],[Name],[DateCreated],[DateModified]) VALUES (newId() ,0,'Other',getdate(),getdate())");

            //Liability
            toAdd.Add("INSERT INTO [dbo].[AppliationFinancialOptions] ([Id],[AppliationFinancialType],[Name],[DateCreated],[DateModified]) VALUES (newId() ,1,'Mortgage/Home',getdate(),getdate())");
            toAdd.Add("INSERT INTO [dbo].[AppliationFinancialOptions] ([Id],[AppliationFinancialType],[Name],[DateCreated],[DateModified]) VALUES (newId() ,1,'Hire Purchase',getdate(),getdate())");
            toAdd.Add("INSERT INTO [dbo].[AppliationFinancialOptions] ([Id],[AppliationFinancialType],[Name],[DateCreated],[DateModified]) VALUES (newId() ,1,'Bank/Personal Loan',getdate(),getdate())");
            toAdd.Add("INSERT INTO [dbo].[AppliationFinancialOptions] ([Id],[AppliationFinancialType],[Name],[DateCreated],[DateModified]) VALUES (newId() ,1,'Credit Cards',getdate(),getdate())");
            toAdd.Add("INSERT INTO [dbo].[AppliationFinancialOptions] ([Id],[AppliationFinancialType],[Name],[DateCreated],[DateModified]) VALUES (newId() ,1,'Bank Overdraft',getdate(),getdate())");
            toAdd.Add("INSERT INTO [dbo].[AppliationFinancialOptions] ([Id],[AppliationFinancialType],[Name],[DateCreated],[DateModified]) VALUES (newId() ,1,'Other',getdate(),getdate())");

            //Income
            toAdd.Add("INSERT INTO [dbo].[AppliationFinancialOptions] ([Id],[AppliationFinancialType],[Name],[DateCreated],[DateModified]) VALUES (newId() ,2,'Applicant Take Home PAy',getdate(),getdate())");
            toAdd.Add("INSERT INTO [dbo].[AppliationFinancialOptions] ([Id],[AppliationFinancialType],[Name],[DateCreated],[DateModified]) VALUES (newId() ,2,'Applicant Secondary Income',getdate(),getdate())");
            toAdd.Add("INSERT INTO [dbo].[AppliationFinancialOptions] ([Id],[AppliationFinancialType],[Name],[DateCreated],[DateModified]) VALUES (newId() ,2,'Spouce Take Home PAy',getdate(),getdate())");
            toAdd.Add("INSERT INTO [dbo].[AppliationFinancialOptions] ([Id],[AppliationFinancialType],[Name],[DateCreated],[DateModified]) VALUES (newId() ,2,'Spuoce Secondary Income',getdate(),getdate())");
            toAdd.Add("INSERT INTO [dbo].[AppliationFinancialOptions] ([Id],[AppliationFinancialType],[Name],[DateCreated],[DateModified]) VALUES (newId() ,2,'Rental Income',getdate(),getdate())");
            toAdd.Add("INSERT INTO [dbo].[AppliationFinancialOptions] ([Id],[AppliationFinancialType],[Name],[DateCreated],[DateModified]) VALUES (newId() ,2,'Government Subsidy',getdate(),getdate())");
            toAdd.Add("INSERT INTO [dbo].[AppliationFinancialOptions] ([Id],[AppliationFinancialType],[Name],[DateCreated],[DateModified]) VALUES (newId() ,2,'Other',getdate(),getdate())");

            //Expense
            toAdd.Add("INSERT INTO [dbo].[AppliationFinancialOptions] ([Id],[AppliationFinancialType],[Name],[DateCreated],[DateModified]) VALUES (newId() ,3,'Mortgage/Rent payments',getdate(),getdate())");
            toAdd.Add("INSERT INTO [dbo].[AppliationFinancialOptions] ([Id],[AppliationFinancialType],[Name],[DateCreated],[DateModified]) VALUES (newId() ,3,'Hire Purchase',getdate(),getdate())");
            toAdd.Add("INSERT INTO [dbo].[AppliationFinancialOptions] ([Id],[AppliationFinancialType],[Name],[DateCreated],[DateModified]) VALUES (newId() ,3,'Bank Personal Loan',getdate(),getdate())");
            toAdd.Add("INSERT INTO [dbo].[AppliationFinancialOptions] ([Id],[AppliationFinancialType],[Name],[DateCreated],[DateModified]) VALUES (newId() ,3,'Credit Cards',getdate(),getdate())");
            toAdd.Add("INSERT INTO [dbo].[AppliationFinancialOptions] ([Id],[AppliationFinancialType],[Name],[DateCreated],[DateModified]) VALUES (newId() ,3,'Rates/Phone/Power',getdate(),getdate())");
            toAdd.Add("INSERT INTO [dbo].[AppliationFinancialOptions] ([Id],[AppliationFinancialType],[Name],[DateCreated],[DateModified]) VALUES (newId() ,3,'Other',getdate(),getdate())");

            return toAdd;
        }
    }
}

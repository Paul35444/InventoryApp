namespace InventoryApp.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class OverrideConventionsForItemsAndCompanies : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Items", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.Items", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Items", new[] { "Company_Id" });
            DropIndex("dbo.Items", new[] { "User_Id" });
            AlterColumn("dbo.Companies", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Companies", "ContactName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Companies", "ContactNumber", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Items", "Description", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Items", "Company_Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Items", "User_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Items", "Company_Id");
            CreateIndex("dbo.Items", "User_Id");
            AddForeignKey("dbo.Items", "Company_Id", "dbo.Companies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Items", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Items", "Company_Id", "dbo.Companies");
            DropIndex("dbo.Items", new[] { "User_Id" });
            DropIndex("dbo.Items", new[] { "Company_Id" });
            AlterColumn("dbo.Items", "User_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Items", "Company_Id", c => c.Byte());
            AlterColumn("dbo.Items", "Description", c => c.String());
            AlterColumn("dbo.Companies", "ContactNumber", c => c.String());
            AlterColumn("dbo.Companies", "ContactName", c => c.String());
            AlterColumn("dbo.Companies", "Name", c => c.String());
            CreateIndex("dbo.Items", "User_Id");
            CreateIndex("dbo.Items", "Company_Id");
            AddForeignKey("dbo.Items", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Items", "Company_Id", "dbo.Companies", "Id");
        }
    }
}

namespace InventoryApp.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddForeignKeyPropertiesToItem : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Items", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Items", new[] { "User_Id" });
            RenameColumn(table: "dbo.Items", name: "User_Id", newName: "UserId");
            AddColumn("dbo.Items", "CompanyId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Items", "Company", c => c.String());
            AlterColumn("dbo.Items", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Items", "UserId");
            AddForeignKey("dbo.Items", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Items", new[] { "UserId" });
            AlterColumn("dbo.Items", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Items", "Company", c => c.String(nullable: false));
            DropColumn("dbo.Items", "CompanyId");
            RenameColumn(table: "dbo.Items", name: "UserId", newName: "User_Id");
            CreateIndex("dbo.Items", "User_Id");
            AddForeignKey("dbo.Items", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}

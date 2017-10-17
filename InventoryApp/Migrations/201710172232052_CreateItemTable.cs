namespace InventoryApp.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreateItemTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                        ContactName = c.String(),
                        ContactNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Description = c.String(),
                        Cost = c.String(),
                        Quantity = c.Int(nullable: false),
                        Company_Id = c.Byte(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.Company_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Company_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Items", "Company_Id", "dbo.Companies");
            DropIndex("dbo.Items", new[] { "User_Id" });
            DropIndex("dbo.Items", new[] { "Company_Id" });
            DropTable("dbo.Items");
            DropTable("dbo.Companies");
        }
    }
}

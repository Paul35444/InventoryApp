namespace InventoryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedCompanyId : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Items", "CompanyId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "CompanyId", c => c.Byte(nullable: false));
        }
    }
}

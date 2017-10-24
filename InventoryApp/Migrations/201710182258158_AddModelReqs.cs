namespace InventoryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModelReqs : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Items", "Company", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Items", "Company", c => c.String());
        }
    }
}

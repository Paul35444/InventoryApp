namespace InventoryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedItemModelReqs : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Items", "Company", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Items", "Company", c => c.String(nullable: false));
        }
    }
}

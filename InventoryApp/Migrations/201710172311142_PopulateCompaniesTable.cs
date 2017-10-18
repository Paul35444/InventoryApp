namespace InventoryApp.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateCompaniesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Companies (Id, Name, ContactName, ContactNumber) VALUES (1, 'Company_1', 'John_Smith_1', '8675309')");
            Sql("INSERT INTO Companies (Id, Name, ContactName, ContactNumber) VALUES (2, 'Company_2', 'John_Smith_2', '8675309')");
            Sql("INSERT INTO Companies (Id, Name, ContactName, ContactNumber) VALUES (3, 'Company_3', 'John_Smith_3', '8675309')");
            Sql("INSERT INTO Companies (Id, Name, ContactName, ContactNumber) VALUES (4, 'Company_4', 'John_Smith_4', '8675309')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Companies WHERE Id IN (1, 2, 3, 4)");
        }
    }
}

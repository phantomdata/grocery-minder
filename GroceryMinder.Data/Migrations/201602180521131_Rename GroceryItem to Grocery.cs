namespace GroceryMinder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameGroceryItemtoGrocery : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.GroceryItems", newName: "Groceries");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Groceries", newName: "GroceryItems");
        }
    }
}

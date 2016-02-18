namespace GroceryMinder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameGroceryItemIdtoIdinGroceries : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Groceries", "GroceryItemId", "Id");
        }
        
        public override void Down()
        {
            RenameColumn("dbo.Groceries", "Id", "GroceryItemId");
        }
    }
}

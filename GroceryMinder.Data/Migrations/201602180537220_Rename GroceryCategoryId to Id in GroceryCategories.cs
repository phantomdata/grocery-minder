namespace GroceryMinder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameGroceryCategoryIdtoIdinGroceryCategories : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.GroceryCategories", "GroceryCategoryId", "Id");
        }
        
        public override void Down()
        {
            RenameColumn("dbo.GroceryCategories", "Id", "GroceryCategoryId");
        }
    }
}

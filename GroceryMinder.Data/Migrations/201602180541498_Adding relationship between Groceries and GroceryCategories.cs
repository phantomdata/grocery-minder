namespace GroceryMinder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingrelationshipbetweenGroceriesandGroceryCategories : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Groceries", "GroceryCategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.GroceryCategories", "GroceryCategory_Id", c => c.Int());
            CreateIndex("dbo.Groceries", "GroceryCategoryId");
            CreateIndex("dbo.GroceryCategories", "GroceryCategory_Id");
            AddForeignKey("dbo.GroceryCategories", "GroceryCategory_Id", "dbo.GroceryCategories", "Id");
            AddForeignKey("dbo.Groceries", "GroceryCategoryId", "dbo.GroceryCategories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Groceries", "GroceryCategoryId", "dbo.GroceryCategories");
            DropForeignKey("dbo.GroceryCategories", "GroceryCategory_Id", "dbo.GroceryCategories");
            DropIndex("dbo.GroceryCategories", new[] { "GroceryCategory_Id" });
            DropIndex("dbo.Groceries", new[] { "GroceryCategoryId" });
            DropColumn("dbo.GroceryCategories", "GroceryCategory_Id");
            DropColumn("dbo.Groceries", "GroceryCategoryId");
        }
    }
}

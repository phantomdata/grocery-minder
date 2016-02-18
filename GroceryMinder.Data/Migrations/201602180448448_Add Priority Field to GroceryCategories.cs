namespace GroceryMinder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPriorityFieldtoGroceryCategories : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GroceryCategories", "Priority", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GroceryCategories", "Priority");
        }
    }
}

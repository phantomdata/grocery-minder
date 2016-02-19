namespace GroceryMinder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAverageCosttoGroceries : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Groceries", "AverageCost", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Groceries", "AverageCost");
        }
    }
}

namespace GroceryMinder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNextPurchaseDatetoGroceries : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Groceries", "NextPurchaseAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Groceries", "NextPurchaseAt");
        }
    }
}

namespace GroceryMinder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLastPurchasedAtandPurchaseFrequencytoGroceryItems : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GroceryItems", "LastPurchasedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.GroceryItems", "PurchaseFrequency", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GroceryItems", "PurchaseFrequency");
            DropColumn("dbo.GroceryItems", "LastPurchasedAt");
        }
    }
}

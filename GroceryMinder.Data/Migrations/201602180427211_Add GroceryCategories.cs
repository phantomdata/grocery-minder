namespace GroceryMinder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGroceryCategories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GroceryCategories",
                c => new
                    {
                        GroceryCategoryId = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.GroceryCategoryId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GroceryCategories", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.GroceryCategories", new[] { "ApplicationUserId" });
            DropTable("dbo.GroceryCategories");
        }
    }
}

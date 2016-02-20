namespace GroceryMinder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateGroceryListCompletionTokens : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GroceryListCompletionTokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(maxLength: 128),
                        Token = c.Guid(nullable: false),
                        ExpiresAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GroceryListCompletionTokens", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.GroceryListCompletionTokens", new[] { "ApplicationUserId" });
            DropTable("dbo.GroceryListCompletionTokens");
        }
    }
}

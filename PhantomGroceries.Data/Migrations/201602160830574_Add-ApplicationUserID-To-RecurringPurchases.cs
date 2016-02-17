namespace PhantomPurchases.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddApplicationUserIDToRecurringPurchases : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RecurringPurchases", "ApplicationUserID", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RecurringPurchases", "ApplicationUserID");
        }
    }
}

// <auto-generated />
namespace PhantomPurchases.Data.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.1.3-40302")]
    public sealed partial class AddApplicationUserIDToRecurringPurchases : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(AddApplicationUserIDToRecurringPurchases));
        
        string IMigrationMetadata.Id
        {
            get { return "201602160830574_Add-ApplicationUserID-To-RecurringPurchases"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}
using PhantomGroceries.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace PhantomGroceries.Data.Configurations
{
    public class GroceryItemConfiguration : EntityTypeConfiguration<GroceryItem>
    {
        public GroceryItemConfiguration()
        {
            ToTable("GroceryItems");
            Property(c => c.Name).IsRequired().HasMaxLength(255);
            HasKey(c => c.GroceryItemID);
        }
    }
}

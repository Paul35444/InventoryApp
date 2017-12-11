using InventoryApp.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace InventoryApp.Persistence.EntityConfigurations
{
    public class ItemConfiguration : EntityTypeConfiguration<Item>
    {
        public ItemConfiguration()
        {
            Property(i => i.UserId)
                .IsRequired();

            Property(i => i.Description)
                .IsRequired()
                .HasMaxLength(255);

            Property(i => i.UserId)
                .IsRequired();

            Property(i => i.Company)
                .IsRequired();

            Property(i => i.Cost)
                .IsRequired();

            Property(i => i.Quantity)
                .IsRequired();

        }
    }
}
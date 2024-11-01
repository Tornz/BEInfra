


using App.Domain.Products;
using App.Domain.Products.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BellaDinner.Infrastructure.Persistence.Configurations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            ConfigureCustomerTable(builder);      
        }      
        private static void ConfigureCustomerTable(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(x => x.Id);

            builder.Property(m => m.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value,
                value => ProductId.Create(value));

            builder.Property(m => m.Name)
                .HasMaxLength(255);
      
            builder.Property(m => m.InterestRate)
                .IsRequired()
                 .HasColumnType("float");

        }
    }
}


using App.Domain.Customers;
using App.Domain.Customers.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BellaDinner.Infrastructure.Persistence.Configurations
{
    public class CustomerConfigurations : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            ConfigureCustomerTable(builder);      
        }      
        private static void ConfigureCustomerTable(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");
            builder.HasKey(x => x.Id);

            builder.Property(m => m.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value,
                value => CustomerId.Create(value));

            builder.Property(m => m.Term)
                .HasMaxLength(100);

            builder.Property(m => m.Title)
                .HasMaxLength(225);

            builder.Property(m => m.FirstName)
           .HasMaxLength(100);

            builder.Property(m => m.LastName)
            .HasMaxLength(100);


            builder.Property(m => m.Mobile)
            .HasMaxLength(225);


            builder.Property(m => m.Email)
            .HasMaxLength(225);

            builder.Property(m => m.DateofBirth)
                 .IsRequired()
                 .HasColumnType("datetime")
                 .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(m => m.AmountRequired)
                .IsRequired()
                 .HasColumnType("float");

        }
    }
}

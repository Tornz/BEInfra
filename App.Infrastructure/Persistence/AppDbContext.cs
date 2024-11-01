

using App.Domain.Customers;
using App.Domain.Products;
using Microsoft.EntityFrameworkCore;


namespace App.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
   
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
      
    }
}


//dotnet ef migrations add InitialCreate --project App.Infrastructure --startup-project App.Api
//dotnet ef database update --project App.Infrastructure --startup-project App.Api --connection "Server=localhost;Database=my_database;User=root;Password=password;"
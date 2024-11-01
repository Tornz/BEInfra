

using App.Domain.Common.Models;
using App.Domain.Products.ValueObjects;

namespace App.Domain.Products
{
    public sealed class Product : AggregateRoot<ProductId>
    {
      
        public string Name { get; private set; }        
        public float InterestRate { get; private set; }
        public ProductId Id { get;  set; } // Include the Id property

        public Product(ProductId productId, string name, float interestRate) : base(productId)
        {
            
            Name = name;
            InterestRate = interestRate;            
        }

     

        public static Product Create(string name, float interestRate)
        {
            return new(ProductId.CreateUnique(), name, interestRate);
        }
      



#pragma warning disable CS8618
        private Product()
        {

        }
#pragma warning restore CS8618

    }
}

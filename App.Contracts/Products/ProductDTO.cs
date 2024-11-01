
namespace App.Contracts.Products
{
    public class ProductDto
    {
        public string Name { get; set; }
        public float InterestRate { get; set; }
        public IdDto Id { get; set; }
    }

    public class IdDto
    {
        public Guid Value { get; set; }
    }
}

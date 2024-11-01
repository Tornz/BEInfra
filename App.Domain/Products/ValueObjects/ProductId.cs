


using App.Domain.Common.Models;

namespace App.Domain.Products.ValueObjects
{
    public sealed class ProductId : ValueObject
    {
        public Guid Value { get; set; }

        public ProductId(Guid value)
        {
            Value = value;
        }

        public static ProductId CreateUnique()
        {
            return new(Guid.NewGuid());  
        }

        public static ProductId Create(Guid value)
        {
            return new ProductId(value);
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}

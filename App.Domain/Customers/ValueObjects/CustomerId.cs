


using App.Domain.Common.Models;

namespace App.Domain.Customers.ValueObjects
{
    public sealed class CustomerId : ValueObject
    {
        public Guid Value { get; }

        public CustomerId(Guid value) {
            Value = value;
        }

        public static CustomerId CreateUnique()
        {
            return new(Guid.NewGuid());  
        }

        public static CustomerId Create(Guid value)
        {
            return new CustomerId(value);
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}

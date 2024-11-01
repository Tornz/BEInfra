

using ErrorOr;

namespace App.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Customer
        {
            public static Error YearsOldNotValid => Error.Validation(code: "Customer.YearsOldNotValid",
                description: "Years old not valid");
        }
    }
}

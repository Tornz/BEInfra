

namespace App.Application.UnitTests.Customers.TestUtils.Contants
{
    public static class Constants
    {
        public static class Customer
        {
            public static readonly Guid Id = Guid.NewGuid();
            public const string Term = "Term";
            public const string Title = "Mr.";
            public const string FirstName = "Lee";
            public const string LastName = "Brown";
            public static readonly DateTime DateOfBirth = new DateTime(2000, 1, 1);
            public const string Mobile = "09565584124";
            public const string Email = "lee@yahoo.com";
            public const decimal AmountRequired = 2000;
        }
    }
}

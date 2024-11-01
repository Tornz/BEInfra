


using App.Application.UnitTests.Customers.TestUtils.Contants;
using App.Domain.Customers;
using App.Domain.Customers.ValueObjects;


namespace App.Application.UnitTests.Customers.Commands.TestUtils
{
    public static class UpdateCustomerCommandUtils
    {
        public static Customer CreateCommand(CustomerId Id, string? dateOfBirth = null) =>
            new Customer(Id, Constants.Customer.Term,
                Constants.Customer.Title,
                Constants.Customer.FirstName,
                Constants.Customer.LastName,
                dateOfBirth != null ? Convert.ToDateTime(dateOfBirth) : Constants.Customer.DateOfBirth,
                Constants.Customer.Mobile,
                Constants.Customer.Email,
                Constants.Customer.AmountRequired);                
    }
}




using App.Application.Customers.Commands.CreateCustomer;
using App.Application.UnitTests.Customers.TestUtils.Contants;


namespace App.Application.UnitTests.Customers.Commands.TestUtils
{
    public static class CreateCustomerCommandUtils
    {
        public static CreateCustomerCommand CreateCommand(
            string? dateOfBirth = null) =>
            new CreateCustomerCommand(Constants.Customer.Term,
                Constants.Customer.Title,
                Constants.Customer.FirstName,
                Constants.Customer.LastName,
                dateOfBirth!=null?  Convert.ToDateTime(dateOfBirth) : Constants.Customer.DateOfBirth,
                Constants.Customer.Mobile,
                Constants.Customer.Email,
                Constants.Customer.AmountRequired);                
    }
}




namespace App.Contracts.Customers
{
    public record class CreateCustomerRequest(
            string Term,
            string Title,
            string FirstName,
            string LastName,
            DateTime DateOfBirth,
            string Mobile,
            string Email,         
            decimal AmountRequired
        );




}

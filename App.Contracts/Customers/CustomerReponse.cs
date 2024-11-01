

namespace App.Contracts.Customers
{
    public record CustomerReponse
    (
        Guid Id,
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

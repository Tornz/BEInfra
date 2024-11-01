
using App.Application.Customers.Commands.CreateCustomer;
using App.Domain.Customers;
using FluentAssertions;

namespace App.Application.UnitTests.Customers.TestUtils.Customers.Extensions
{
    public static partial class  CustomerExtension
    {
        public static void ValidateCreatedFrom(this Customer customer, CreateCustomerCommand command)
        {
            customer.Id.Should().NotBeNull();
            customer.FirstName.Should().Be(command.FirstName);
            customer.LastName.Should().Be(command.LastName);
            customer.Term.Should().Be(command.Term);
            customer.Email.Should().Be(command.Email);
            customer.Mobile.Should().Be(command.Mobile);            
        }
    }
}

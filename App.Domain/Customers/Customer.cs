

using App.Domain.Common.Models;
using App.Domain.Customers.ValueObjects;

namespace App.Domain.Customers
{
    public sealed class Customer:AggregateRoot<CustomerId>
    {
        public string Term { get; private set; }
        public string Title { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime DateofBirth { get; private set; }
        public string Mobile { get; private set; }
        public string Email { get; private set; }
        public decimal AmountRequired { get; private set; }

        public Customer(CustomerId customerId, string term, string title,string firstName, 
            string lastName, DateTime dateOfBirth, string mobile, string email, decimal amountRequired) : base(customerId)
        {
            Term = term;
            Title = title;
            FirstName = firstName;
            LastName = lastName;
            DateofBirth = dateOfBirth;
            Mobile = mobile;
            Email = email;
            AmountRequired = amountRequired;
        }
        public static Customer Create(string term, string title, string firstName,
            string lastName, DateTime dateOfBirth, string mobile, string email, decimal amountRequired)
        {
            return new(CustomerId.CreateUnique(), term, title, firstName, lastName , dateOfBirth, mobile, email, amountRequired);
        }

#pragma warning disable CS8618
        private Customer()
        {

        }
#pragma warning restore CS8618

    }
}

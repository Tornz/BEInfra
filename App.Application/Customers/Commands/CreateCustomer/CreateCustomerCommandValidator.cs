

using FluentValidation;

namespace App.Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator() {           
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.DateOfBirth).NotEmpty();
            RuleFor(x => x.Mobile).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress()
            .WithMessage("Email is not valid.");
        }
    }
}

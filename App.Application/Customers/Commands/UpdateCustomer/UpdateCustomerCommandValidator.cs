﻿

using FluentValidation;

namespace App.Application.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator() {
            RuleFor(x => x.Id).NotEmpty();
        
        }
    }
}

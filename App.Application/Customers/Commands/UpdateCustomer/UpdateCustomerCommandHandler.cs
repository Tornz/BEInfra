using App.Application.Interfaces.Persistance;
using App.Application.Interfaces.Services;
using App.Domain.Customers;
using ErrorOr;
using MediatR;
using App.Domain.Common.Errors;
using App.Domain.Customers.ValueObjects;

namespace App.Application.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, ErrorOr<Customer>>
    {

        private readonly ICustomerRepository _customerRepository;
        private readonly IDateTimeProvider _dateTimeProvider;


        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IDateTimeProvider dateTimeProvider)
        {
            _customerRepository = customerRepository;
            _dateTimeProvider = dateTimeProvider;


        }

        public async Task<ErrorOr<Customer>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var now = _dateTimeProvider.UtcNow;
            var customerId = new CustomerId(request.Id);
            var customer=  await _customerRepository.GetUserById(customerId);
            var numberyears = GetYearsBetweenDates(customer.DateofBirth, now);
            if (numberyears < 18)
            {
                return Errors.Customer.YearsOldNotValid;
            }



            return customer;
        }

        private int GetYearsBetweenDates(DateTime startDate, DateTime endDate)
        {
            // Ensure startDate is before endDate
            if (startDate > endDate)
            {
                throw new ArgumentException("startDate must be before endDate");
            }

            // Calculate the preliminary difference in years
            int years = endDate.Year - startDate.Year;

            // Adjust for cases where the birthday hasn't occurred yet in the end year
            if (startDate > endDate.AddYears(-years))
            {
                years--;
            }

            return years;
        }
    }
}

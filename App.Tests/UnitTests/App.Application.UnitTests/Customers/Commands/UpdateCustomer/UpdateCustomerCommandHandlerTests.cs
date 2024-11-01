

using App.Application.Customers.Commands.CreateCustomer;
using App.Application.Customers.Commands.UpdateCustomer;
using App.Application.Interfaces.Persistance;
using App.Application.Interfaces.Services;
using App.Application.UnitTests.Customers.Commands.TestUtils;
using App.Application.UnitTests.Customers.TestUtils.Customers.Extensions;
using App.Domain.Common.Errors;
using App.Domain.Customers;
using App.Domain.Customers.ValueObjects;
using FluentAssertions;
using Moq;

namespace App.Application.UnitTests.Customers.Commands.CreateCustomer
{
    public class UpdateCustomerCommandHandlerTests
    {
        //T1: SUT - logical component we're testing
        //T2 : Scenario - what we're testing
        //T3: Expected outcome - what expect the logical component do

        private readonly Mock<ICustomerRepository> _customerRepositoryMock;
        private readonly Mock<IDateTimeProvider> _dateTimeProviderMock;
        private readonly UpdateCustomerCommandHandler _handler;

        public UpdateCustomerCommandHandlerTests()
        {

            _customerRepositoryMock = new Mock<ICustomerRepository>();
            _dateTimeProviderMock = new Mock<IDateTimeProvider>();
            _handler = new UpdateCustomerCommandHandler(_customerRepositoryMock.Object, _dateTimeProviderMock.Object);

        }

        [Fact]
        public async Task Handle_ShouldReturnCustomer_WhenCustomerIsOver18()
        {
            //Arrange        
            var customerId = Guid.NewGuid();
            var command = new UpdateCustomerCommand(customerId);

            var customer = UpdateCustomerCommandUtils.CreateCommand(new CustomerId(customerId));

            _customerRepositoryMock
                .Setup(repo => repo.GetUserById(It.IsAny<CustomerId>()))
                .ReturnsAsync(customer);

            _dateTimeProviderMock
                .Setup(provider => provider.UtcNow)
                .Returns(DateTime.Now);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsError.Should().BeFalse();
        }

        [Fact]
        public async Task Handle_ShouldReturnError_WhenCustomerIsUnder18()
        {
            //Arrange        
            var customerId = Guid.NewGuid();
            var command = new UpdateCustomerCommand(customerId);

            var customer = UpdateCustomerCommandUtils.CreateCommand(new CustomerId(customerId), dateOfBirth: DateTime.Now.ToString("yyyy-MM-dd"));

            _customerRepositoryMock
                .Setup(repo => repo.GetUserById(It.IsAny<CustomerId>()))
                .ReturnsAsync(customer);

            _dateTimeProviderMock
                .Setup(provider => provider.UtcNow)
                .Returns(DateTime.Now);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
          
            result.IsError.Should().BeTrue();
            Assert.Equal(Errors.Customer.YearsOldNotValid.Code, result.Errors.First().Code);
       

        }







    }
}

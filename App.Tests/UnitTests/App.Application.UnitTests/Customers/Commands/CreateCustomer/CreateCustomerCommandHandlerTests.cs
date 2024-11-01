

using App.Application.Customers.Commands.CreateCustomer;
using App.Application.Interfaces.Persistance;
using App.Application.Interfaces.Services;
using App.Application.UnitTests.Customers.Commands.TestUtils;
using App.Application.UnitTests.Customers.TestUtils.Customers.Extensions;
using FluentAssertions;
using Moq;

namespace App.Application.UnitTests.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandlerTests
    {
        //T1: SUT - logical component we're testing
        //T2 : Scenario - what we're testing
        //T3: Expected outcome - what expect the logical component do

        private readonly CreateCustomerCommandHandler _handler;
        private readonly Mock<ICustomerRepository> _mockCustomerRepository;        

        public CreateCustomerCommandHandlerTests()
        {            
            _mockCustomerRepository = new Mock<ICustomerRepository> ();            
            _handler = new CreateCustomerCommandHandler(_mockCustomerRepository.Object );
        }

        [Fact]
        public async Task HandleCreateCustomerCommand_WhenCustomerIsValid_ShouldCreateAndReturnCustomer()
        {
            //Arrange
            var createCustomerCommand = CreateCustomerCommandUtils.CreateCommand();
            
            //Act
            var result = await _handler.Handle(createCustomerCommand, default);

            //Assert
            result.IsError.Should().BeFalse();
            result.Value.ValidateCreatedFrom(createCustomerCommand);
            _mockCustomerRepository.Verify(m => m.Add(result.Value), Times.Once);
        }





    }
}

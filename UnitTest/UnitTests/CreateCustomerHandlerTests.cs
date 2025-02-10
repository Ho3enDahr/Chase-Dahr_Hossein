using crud_test_dotnet.Core.Domain.Interfaces;
using Moq;
using crud_test_dotnet.Core.Application.Customers.Handlers;
using Xunit;
using crud_test_dotnet.Core.Application.Customers.Commands;
using crud_test_dotnet.Core.Domain.Entities.CustomerManagement;

namespace UnitTest.UnitTests
{
    public class CreateCustomerHandlerTests
    {
        private readonly Mock<ICustomerRepository> _customerRepositoryMock;
        private readonly Mock<IEventStore> _eventstoreMock;
        private readonly CreateCustomerCommandHandler _handler;
        public CreateCustomerHandlerTests()
        {
            _customerRepositoryMock = new Mock<ICustomerRepository>();
            _handler = new CreateCustomerCommandHandler(_customerRepositoryMock.Object, _eventstoreMock.Object);
        }
        [Fact]
        public async Task Handle_ShouldReturnCustomerWhenCreated()
        {
            var command = new CreateCustomerCommand
            {
                BankAccountNumber = "12365478921",
                DateOfBirth = DateTime.Now,
                Email = "ho3en.dah1r@gmail.com",
                FirstName = "ssade",
                LastName = "dahr",
                PhoneNumber = "9147889243"
            };
            var exceptedCustomer = new Customer();
            var result = await _handler.Handle(command,CancellationToken.None);
            Assert.Equal(exceptedCustomer, result);
        }
    }
}

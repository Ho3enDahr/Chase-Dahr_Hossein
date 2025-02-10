using crud_test_dotnet.Core.Application.Customers.Commands;
using crud_test_dotnet.Core.Application.Customers.Handlers;
using crud_test_dotnet.Core.Domain.Entities.CustomerManagement;
using crud_test_dotnet.Core.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;

namespace UnitTest.BDD
{
    [Binding]
    public class CreateCustomerStepDefinitions
    {
        private readonly CreateCustomerCommandHandler _handler;
        private CreateCustomerCommand _command;
        private Customer _result;
        private readonly IEventStore _eventStore;
        public CreateCustomerStepDefinitions()
        {
            var customerRepositoryMock = new Mock<ICustomerRepository>();
            customerRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Customer>()))
                                  .ReturnsAsync(new Customer());

            _handler = new CreateCustomerCommandHandler(customerRepositoryMock.Object, _eventStore);
        }

        [Given(@"I have customer details")]
        public void GivenIHaveCustomerDetails()
        {
            _command = new CreateCustomerCommand { FirstName = "John", LastName = "Doe", Email = "john@example.com" };
        }

        [When(@"I submit the request")]
        public async Task WhenISubmitTheRequest()
        {
            _result = await _handler.Handle(_command, CancellationToken.None);
        }

        [Then(@"a new customer should be created")]
        public void ThenANewCustomerShouldBeCreated()
        {
            Assert.NotEqual(new Customer(), _result);
        }
    }

}

using crud_test_dotnet.Core.Domain.Events;
using crud_test_dotnet.Core.Domain.ValueObjects;
using PhoneNumbers;

namespace crud_test_dotnet.Core.Domain.Entities.CustomerManagement
{
    public class Customer : IAggregateRoot
    {
        private List<DomainEvent> _domainEvents = new List<DomainEvent>();
        public Guid Id { get;private set; }
        public string FirstName { get;private set; }
        public string LastName { get;private set; }
        public DateTime DateOfBirth { get;private set; }
        public ValueObjects.PhoneNumber PhoneNumber { get;private set; }
        public Email Email { get;private set; }
        public BankAccountNumber BankAccountNumber { get;private set; }

        public IReadOnlyList<DomainEvent> GetEvents() => _domainEvents.AsReadOnly();
        public Customer()
        {
            
        }
        public Customer(Guid id, string firstName, string lastName, DateTime dateOfBirth, string phoneNumber, string email, string bankAccountNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            PhoneNumber = new ValueObjects.PhoneNumber(phoneNumber);
            Email =new Email(email);
            BankAccountNumber =new BankAccountNumber(bankAccountNumber);
        }
        public static Customer Create(string firstname,string lastname,string phoneNumber,string email,string bankAccountNumber,DateTime dateOfBirth)
        {
            var customer = new Customer()
            {
                BankAccountNumber =new BankAccountNumber( bankAccountNumber),
                DateOfBirth = dateOfBirth,
                Email = new Email(email),
                FirstName=firstname,
                Id = Guid.NewGuid(),
                LastName=lastname,
                PhoneNumber = new ValueObjects.PhoneNumber(phoneNumber)
            };
            customer.AddEvent(new CustomerCreatedEvent(customer.Id, customer.FirstName, customer.LastName, customer.PhoneNumber.Value, customer.Email.Value, customer.BankAccountNumber.Value,customer.DateOfBirth), customer.Id);
            return customer;
        }
        public static Customer Update(Guid id,string firstname, string lastname, string phoneNumber, string email, string bankAccountNumber, DateTime dateOfBirth)
        {
            var customer = new Customer()
            {
                BankAccountNumber = new BankAccountNumber(bankAccountNumber),
                DateOfBirth = dateOfBirth,
                Email = new Email(email),
                FirstName = firstname,
                Id = id,
                LastName = lastname,
                PhoneNumber = new ValueObjects.PhoneNumber(phoneNumber)
            };
            customer.AddEvent(new CustomerUpdatedEvent(customer.Id, customer.FirstName, customer.LastName, customer.PhoneNumber.Value, customer.Email.Value, customer.BankAccountNumber.Value,customer.DateOfBirth), customer.Id);
            return customer;
        }
        public static Customer Delete(Guid id, string firstname, string lastname, string phoneNumber, string email, string bankAccountNumber, DateTime dateOfBirth)
        {
            var customer = new Customer()
            {
                BankAccountNumber = new BankAccountNumber(bankAccountNumber),
                DateOfBirth = dateOfBirth,
                Email = new Email(email),
                FirstName = firstname,
                Id = id,
                LastName = lastname,
                PhoneNumber = new ValueObjects.PhoneNumber(phoneNumber)
            };
            customer.AddEvent(new CustomerDeletedEvent(customer.Id, customer.FirstName, customer.LastName, customer.PhoneNumber.Value, customer.Email.Value, customer.BankAccountNumber.Value, customer.DateOfBirth),customer.Id);
            return customer;
        }
        public void ChangeEmail(string newEmail)
        {
            if (string.IsNullOrEmpty(newEmail))
                throw new ArgumentException("Email cannot be empty.");
            Email = new Email(newEmail);
            var customerEmailChangedEvent = new CustomerEmailChangedEvent(Id, Email.Value);
            _domainEvents.Add(customerEmailChangedEvent);
        }
        public void AddEvent(DomainEvent @event,Guid aggregateId)
        {
            @event.AggregateId = aggregateId;
            _domainEvents.Add(@event);
        }
    }
}

using crud_test_dotnet.Core.Domain.Events;
using crud_test_dotnet.Core.Domain.ValueObjects;

namespace crud_test_dotnet.Core.Domain.Entities.CustomerManagement
{
    public class Customer : IAggregateRoot
    {
        private List<DomainEvent> _domainEvents = new List<DomainEvent>();
        public Guid Id { get;private set; }
        public string FirstName { get;private set; }
        public string LastName { get;private set; }
        public DateTime DateOfBirth { get;private set; }
        public PhoneNumber PhoneNumber { get;private set; }
        public Email Email { get;private set; }
        public BankAccountNumber BankAccountNumber { get;private set; }

        public IReadOnlyList<DomainEvent> GetEvents => _domainEvents.AsReadOnly();
        public Customer()
        {
            
        }
        public Customer(Guid id, string firstName, string lastName, DateTime dateOfBirth, PhoneNumber phoneNumber, Email email, BankAccountNumber bankAccountNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            PhoneNumber = new PhoneNumber(phoneNumber.Value);
            Email =new Email(email.Value);
            BankAccountNumber =new BankAccountNumber(bankAccountNumber.Value);
        }
        public static Customer Create(string firstname,string lastname,string phoneNumber,string email,string bankAccountNumber,DateTime dateOfBirth)
        {
            var customer = new Customer()
            {
                BankAccountNumber =new BankAccountNumber( bankAccountNumber),
                DateOfBirth = dateOfBirth,
                Email = new Email(email),
                FirstName=firstname,
                Id = new Guid(),
                LastName=lastname,
                PhoneNumber = new PhoneNumber(phoneNumber)
            };
            customer.AddEvent(new CustomerCreatedEvent(customer.Id, customer.FirstName, customer.LastName, customer.PhoneNumber.Value, customer.Email.Value, customer.BankAccountNumber.Value));
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
        public void AddEvent(DomainEvent @event)
        {
            _domainEvents.Add(@event);
        }
    }
}

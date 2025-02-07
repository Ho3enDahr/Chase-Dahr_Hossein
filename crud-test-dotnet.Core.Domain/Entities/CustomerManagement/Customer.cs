using crud_test_dotnet.Core.Domain.Events;
using crud_test_dotnet.Core.Domain.ValueObjects;

namespace crud_test_dotnet.Core.Domain.Entities.CustomerManagement
{
    public class Customer : IAggregateRoot
    {
        private List<IDomainEvent> _domainEvents = new List<IDomainEvent>();
        public Guid Id { get;private set; }
        public string FirstName { get;private set; }
        public string LastName { get;private set; }
        public DateTime DateOfBirth { get;private set; }
        public PhoneNumber PhoneNumber { get;private set; }
        public Email Email { get;private set; }
        public BankAccountNumber BankAccountNumber { get;private set; }

        public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();
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
        public void ChangeEmail(string newEmail)
        {
            if (string.IsNullOrEmpty(newEmail))
                throw new ArgumentException("Email cannot be empty.");
            Email = new Email(newEmail);
            var customerEmailChangedEvent = new CustomerEmailChangedEvent(Id, Email.Value);
            _domainEvents.Add(customerEmailChangedEvent);
        }
    }
}

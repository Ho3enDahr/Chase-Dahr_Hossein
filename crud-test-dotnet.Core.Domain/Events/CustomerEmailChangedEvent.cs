namespace crud_test_dotnet.Core.Domain.Events
{
    public class CustomerEmailChangedEvent : DomainEvent
    {
        public Guid CustomerId { get;  }
        public string Email { get;  }
        public DateTime Timestamp { get; set; }

        public CustomerEmailChangedEvent(Guid customerId, string email)
        {
            CustomerId = customerId;
            Email = email;
            Timestamp = DateTime.Now;
        }
    }
}

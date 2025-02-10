namespace crud_test_dotnet.Core.Domain.Events
{
    public abstract class DomainEvent
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid AggregateId { get;  set; } 
        public DateTime AccurredOn { get; private set; } = DateTime.Now;
        protected DomainEvent() { }
    }
}

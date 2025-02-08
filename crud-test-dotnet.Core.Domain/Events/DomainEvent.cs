namespace crud_test_dotnet.Core.Domain.Events
{
    public abstract class DomainEvent
    {
        public Guid Id { get; private set; } = new Guid();
        public DateTime AccurredOn { get; private set; } = DateTime.Now;
        protected DomainEvent() { }
    }
}

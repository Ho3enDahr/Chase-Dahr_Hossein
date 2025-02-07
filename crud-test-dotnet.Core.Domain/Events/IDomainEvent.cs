namespace crud_test_dotnet.Core.Domain.Events
{
    public interface IDomainEvent
    {
        public DateTime Timestamp { get; }
    }
}

using crud_test_dotnet.Core.Domain.Events;
using crud_test_dotnet.Core.Domain.Interfaces;
using crud_test_dotnet.Infrastructure.Infrastructure.DBContext;
using crud_test_dotnet.Infrastructure.Infrastructure.Persistence;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace crud_test_dotnet.Infrastructure.Infrastructure.EventStore
{
    public class EventStore : IEventStore
    {
        private readonly CustomerDbContext _context;
        public EventStore(CustomerDbContext context)
        {
            _context =context;
        }
        public List<DomainEvent> GetEvents(Guid aggregateId)
        {
            var events = _context.EventStoreTable.Where(w=>w.AggregateId == aggregateId).OrderBy(o=>o.OccurredOn).ToList();
            return events.Select(e=> JsonConvert.DeserializeObject<DomainEvent>(e.EventData)).ToList();
        }

        public void Save<T>(T @event) where T : DomainEvent
        {
            var eventData = new EventStoreModel
            {
                Id = @event.Id,
                AggregateId = @event.AggregateId,
                EventType = @event.GetType().Name,
                EventData = JsonConvert.SerializeObject(@event),
                OccurredOn = @event.AccurredOn
            };
            _context.EventStoreTable.Add(eventData);
            _context.SaveChanges();
        }
    }
}

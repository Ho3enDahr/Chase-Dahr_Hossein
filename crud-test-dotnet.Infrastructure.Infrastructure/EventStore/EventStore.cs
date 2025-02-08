using crud_test_dotnet.Core.Domain.Events;
using crud_test_dotnet.Core.Domain.Interfaces;
using crud_test_dotnet.Infrastructure.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            throw new NotImplementedException();
        }

        public void Save<T>(T @event) where T : DomainEvent
        {
            throw new NotImplementedException();
        }
    }
}

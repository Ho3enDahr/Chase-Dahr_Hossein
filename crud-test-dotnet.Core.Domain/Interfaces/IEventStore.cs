using crud_test_dotnet.Core.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_test_dotnet.Core.Domain.Interfaces
{
    public interface IEventStore
    {
        void Save<T>(T @event) where T : DomainEvent;
        List<DomainEvent> GetEvents(Guid aggregateId);
    }
}

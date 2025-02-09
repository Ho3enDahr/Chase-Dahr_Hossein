using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_test_dotnet.Infrastructure.Infrastructure.Persistence
{
    public class EventStoreModel
    {
        public Guid Id { get; set; }
        public Guid AggregateId { get; set; }
        public string EventType { get; set; }
        public string EventData { get; set; }
        public DateTime OccurredOn { get; set; }
    }
}

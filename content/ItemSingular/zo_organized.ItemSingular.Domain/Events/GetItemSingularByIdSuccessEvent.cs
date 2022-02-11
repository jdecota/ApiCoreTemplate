using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zo_organized.ItemSingular.Domain.Aggregates;
using zo_organized.Interfaces;

namespace zo_organized.ItemSingular.Domain.Events
{
    public class GetItemSingularByIdSuccessEvent : IDomainEvent
    {
        public DateTime DateOccurred => DateTime.Now;

        public ItemSingularAggregate Aggregate { get; set; }

        public GetItemSingularByIdSuccessEvent(ItemSingularAggregate aggregate)
        {
            Aggregate = aggregate;
        }
    }
}

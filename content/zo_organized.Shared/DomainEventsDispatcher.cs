using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using zo_organized.Interfaces;
using zo_organized.Shared.Interfaces;

namespace zo_organized.Shared
{
    public class DomainEventsDispatcher
    {
        public async Task Dispatch(BaseEntity aggregate)
        {
            if (aggregate != null)
            {
                if (aggregate.Events.Count > 0 && aggregate.DomainEventHandlers.Count > 0)
                {
                    foreach(var domainEvent in aggregate.Events)
                    {
                        foreach(var eventHandlerType in aggregate.DomainEventHandlers)
                        {
                            if(eventHandlerType.Name.Contains(domainEvent.GetType().Name))
                            {
                                var handler = Activator.CreateInstance(eventHandlerType) as IDomainEventHandler<IDomainEvent>;
                                if (handler != null)
                                    await handler.Handle(domainEvent);
                            }
                        }
                    }
                }
            }
        }
    }
}

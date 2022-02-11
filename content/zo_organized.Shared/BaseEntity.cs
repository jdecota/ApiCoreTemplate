using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zo_organized.Interfaces;
using zo_organized.Shared.Interfaces;

namespace zo_organized.Shared
{
    public abstract class BaseEntity
    {
        public List<IDomainEvent> Events = new List<IDomainEvent>();

        public List<Type> DomainEventHandlers = new List<Type>();

        public void AddDomainEventHandlers(List<Type> domainEventHandlers)
        {
            if (domainEventHandlers != null)
            {
                DomainEventHandlers = domainEventHandlers;
            }
        }

        public void AddDomainEventHandler(Type domainEventHandler)
        {
            if (DomainEventHandlers == null)
            {
                DomainEventHandlers = new List<Type>();
            }
            DomainEventHandlers.Add(domainEventHandler);
        }
    }
}

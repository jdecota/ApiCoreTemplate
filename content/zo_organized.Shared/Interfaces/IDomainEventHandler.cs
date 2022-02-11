using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zo_organized.Interfaces;

namespace zo_organized.Shared.Interfaces
{
    public interface IDomainEventHandler<T> where T : IDomainEvent
    {
        Task Handle(T domainEvent);
    }
}

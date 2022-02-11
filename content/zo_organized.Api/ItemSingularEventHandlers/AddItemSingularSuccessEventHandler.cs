using zo_organized.ItemSingular.Domain.Events;
using zo_organized.Interfaces;
using zo_organized.Shared.Interfaces;

namespace zo_organized.Api.ItemSingularEventHandlers
{
    public class AddItemSingularSuccessEventHandler : IDomainEventHandler<IDomainEvent>
    {
        public async Task Handle(IDomainEvent domainEvent)
        {
            var currentEvent = domainEvent as AddItemSingularSuccessEvent;
            if (currentEvent != null)
            {
                // Need to call an other aggregate and make the changes
            }
            return;
        }
    }
}

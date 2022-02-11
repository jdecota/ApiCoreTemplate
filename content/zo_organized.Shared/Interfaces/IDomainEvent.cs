
using zo_organized.Shared.Interfaces;

namespace zo_organized.Interfaces
{
    public interface IDomainEvent
    {
        DateTime DateOccurred { get; }
    }
}

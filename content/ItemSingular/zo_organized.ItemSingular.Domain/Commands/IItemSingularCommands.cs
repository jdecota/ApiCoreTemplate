using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zo_organized.Shared.Interfaces;

namespace zo_organized.ItemSingular.Domain.Commands
{
    public interface IItemSingularCommands<BrandAggregate> : ISqlCommands<IAggregateRoot>
    {
    }
}

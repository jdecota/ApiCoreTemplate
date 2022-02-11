using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zo_organized.Shared.Interfaces;

namespace zo_organized.ItemSingular.Domain.Repositories
{
    public interface IItemSingularRepository<T> : IRepository<T> where T : class, IAggregateRoot
    {
        Task<T> GetItemSingularById(T aggregate);

        Task<T> AddItemSingular(T aggregate);

        Task<T> GetAllItemPlural(T aggregate);
    }
}

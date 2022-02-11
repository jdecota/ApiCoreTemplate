using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zo_organized.Shared.Interfaces
{
    public interface ISqlCommands<T> where T : IAggregateRoot
    {
        Task<T> GetById(T aggregate);

        Task<T> Insert(T aggregate);

        Task<T> Update(T aggregate);

        Task<T> Delete(T aggregate);

        Task<T> GetAll(T aggregate);
    }
}

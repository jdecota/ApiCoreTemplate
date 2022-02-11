using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zo_organized.Shared.Interfaces
{
    public interface ISqlDataAccess<T> where T : IAggregateRoot
    {
        Task<T> GetListDataEntity<R, U>(T aggregate,
            string storedProcedure,
            U parameters,
            string connectionId = "Default") where R : BaseEntity;

        Task<T> GetListDataEntity<R>(T aggregate,
            string storedProcedure,
            string connectionId = "Default") where R : BaseEntity;

        Task<T> GetListDataValueObject<R, U>(T aggregate,
            string storedProcedure,
            U parameters,
            string connectionId = "Default") where R : BaseValueObject;

        Task<T> GetListDataValueObject<R>(T aggregate,
            string storedProcedure,
            string connectionId = "Default") where R : BaseValueObject;

        Task<T> GetDataEntity<R,U>(T aggregate,
            string storedProcedure,
            U parameters,
            string connectionId = "Default") where R : BaseEntity;

        Task<T> GetDataValueObject<R, U>(T aggregate,
            string storedProcedure,
            U parameters,
            string connectionId = "Default") where R : BaseValueObject;

        Task ProcessData<U>(
            string storedProcedure,
            U parameters,
            string connectionId = "Default");
    }
}

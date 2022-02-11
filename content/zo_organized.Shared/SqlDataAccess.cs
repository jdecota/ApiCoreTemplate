using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using zo_organized.Shared.Interfaces;

namespace zo_organized.Shared
{
    public class SqlDataAccess<T> : ISqlDataAccess<T> where T : IAggregateRoot
    {
        private readonly IConfiguration _config;

        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<T> GetDataEntity<R, U>(T aggregate,
            string storedProcedure,
            U parameters,
            string connectionId) where R : BaseEntity
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

            var result = await connection.QueryFirstOrDefaultAsync<R>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            return UpdateAggregate(result, aggregate);
        }

        public async Task<T> GetDataValueObject<R, U>(T aggregate,
           string storedProcedure,
           U parameters,
           string connectionId) where R : BaseValueObject
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

            var result = await connection.QueryFirstOrDefaultAsync<R>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            return UpdateAggregate(result, aggregate);
        }

        public async Task<T> GetListDataEntity<R, U>(T aggregate,
            string storedProcedure,
            U parameters,
            string connectionId) where R : BaseEntity
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

            var result = await connection.QueryAsync<R>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            return UpdateAggregate(result, aggregate);
        }

        public async Task<T> GetListDataEntity<R>(T aggregate,
            string storedProcedure,
            string connectionId) where R : BaseEntity
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

            var result = await connection.QueryAsync<R>(storedProcedure, commandType: CommandType.StoredProcedure);
            return UpdateAggregate(result, aggregate);
        }

        public async Task<T> GetListDataValueObject<R, U>(T aggregate,
            string storedProcedure,
            U parameters,
            string connectionId) where R : BaseValueObject
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

            var result = await connection.QueryAsync<R>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            return UpdateAggregate(result, aggregate);
        }

        public async Task<T> GetListDataValueObject<R>(T aggregate,
            string storedProcedure,
            string connectionId) where R : BaseValueObject
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

            var result = await connection.QueryAsync<R>(storedProcedure, commandType: CommandType.StoredProcedure);
            return UpdateAggregate(result, aggregate);
        }

        public async Task ProcessData<U>(
            string storedProcedure,
            U parameters,
            string connectionId)
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

            await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        private T UpdateAggregate(object result, T aggregate)
        {
            if (result != null)
            {
                var property = typeof(T).GetProperty("ModelPropertyName");
                if (property != null)
                {
                    string? propertyValue = property?.GetValue(aggregate)?.ToString();
                    if (!string.IsNullOrEmpty(propertyValue))
                    {
                        var modelProperty = typeof(T)?.GetProperty(propertyValue);
                        if (modelProperty != null)
                        {
                            modelProperty.SetValue(aggregate, result, BindingFlags.NonPublic | BindingFlags.Instance, null, null, null);
                        }
                    }
                }
            }
            return aggregate;
        }
    }
}

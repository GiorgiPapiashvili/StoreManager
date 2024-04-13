using Dapper;
using Humanizer;
using Microsoft.Data.SqlClient;
using StoreManager.Service.Interfaces.Repositories;
using System.Data;
using System.Reflection;

namespace StoreManager.Repository
{
    internal abstract class RepositoryBase<T> : IRepositoryBase<T>
    {
        protected readonly SqlTransaction? _transaction;
        protected readonly SqlConnection _connection;
         
        protected RepositoryBase(string connectionString, SqlConnection? connection = null, SqlTransaction? transaction = null)
        {
            _connection = connection ?? new SqlConnection(connectionString);
            _transaction = transaction;
        }

        public T Get(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ID", id);

            T item = _connection.QueryFirst<T>(
                $"sp_Get{typeof(T).Name}",
                param: parameters,
                commandType: CommandType.StoredProcedure);

            return item;
        }

        public IEnumerable<T> Load()
        {
            return _connection.Query<T>($"select * from {typeof(T).Name.Pluralize()}");
        }

        public virtual int Insert(T item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            var parameters = GetParameters(item, IgnoredPropertiesForInsert);
            parameters.Add("ID", dbType: DbType.Int32, direction: ParameterDirection.Output);

            _connection.Execute(
                $"sp_insert{typeof(T).Name}",
                param: parameters, 
                transaction: _transaction,
                commandType: CommandType.StoredProcedure);

            return parameters.Get<int>("ID");
        }

        public void Update(T item)
        {
            DynamicParameters parameters = GetParameters(item, IgnoredPropertiesForUpdate);

            _connection.Execute($"sp_Update{typeof(T).Name}",
                param: parameters, 
                transaction: _transaction,
                commandType: CommandType.StoredProcedure);
        }

        public void Delete(int id)
        {
            _connection.Execute(
                $"sp_Delete{typeof(T).Name}", new { ID = id }, 
                transaction: _transaction,
                commandType: CommandType.StoredProcedure);
        }

        private static DynamicParameters GetParameters(T item, IEnumerable<string> extraParameters)
        {
            Type type = item!.GetType();

            PropertyInfo[] properties = type.GetProperties();
            DynamicParameters parameters = new();

            foreach (var prop in properties)
            {
                if (extraParameters.Contains(prop.Name))
                {
                    continue;
                }

                parameters.Add(prop.Name, prop.GetValue(item));
            }

            return parameters;
        }

        protected virtual IEnumerable<string> IgnoredPropertiesForInsert => new[] { $"{typeof(T).Name}Id", "CreatedDate", "UpdatedDate", "IsDeleted" };
        protected virtual IEnumerable<string> IgnoredPropertiesForUpdate => new[] { "CreatedDate", "UpdatedDate", "IsDeleted" };
    }
}

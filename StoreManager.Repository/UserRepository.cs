using Dapper;
using Microsoft.Data.SqlClient;
using StoreManager.DTO;
using StoreManager.Service.Interfaces.Repositories;
using System.Data;

namespace StoreManager.Repository
{
    internal sealed class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(string connectionString, SqlConnection? connection = null, SqlTransaction? transaction = null) : base(connectionString, connection, transaction)
        {

        }

        public override int Insert(User item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            DynamicParameters parameters = new();
            parameters.Add("EmployeeId", item.EmployeeId, dbType: DbType.Int32);
            parameters.Add("UserName", item.UserName, dbType: DbType.String);
            parameters.Add("Password", item.Password, dbType: DbType.String);

            _connection.Execute("sp_InsertUser", parameters, commandType: System.Data.CommandType.StoredProcedure, transaction: _transaction);

            return 0;
        }

        public void Register(int employeeId, string username, string password)
        {
            DynamicParameters parameters = new();
            parameters.Add("EmployeeId", employeeId, DbType.Int32);
            parameters.Add("UserName", username, DbType.String);
            parameters.Add("Password", password, DbType.String);

            _connection.Execute("sp_RegisterUser", parameters, commandType: CommandType.StoredProcedure, transaction: _transaction);
        }

        public bool Login(string username, string password)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@UserName", username, System.Data.DbType.String);
            parameters.Add("Password", password, System.Data.DbType.String);
            parameters.Add("SuccessfullLogin", dbType: DbType.Boolean, direction: ParameterDirection.Output);

            _connection.Execute("sp_userLogin", parameters, commandType: CommandType.StoredProcedure, transaction: _transaction);

            return parameters.Get<bool>("SuccessfullLogin");
        }

        public void ResetPassword(string username, string currentPassword, string newPassword)
        {
            DynamicParameters parameters = new();
            parameters.Add("UserName", username, System.Data.DbType.String);
            parameters.Add("CurrentPassword", currentPassword, System.Data.DbType.String);
            parameters.Add("NewPassword", newPassword, System.Data.DbType.String);

            _connection.Execute("sp_ChangePassword_User", parameters, commandType: System.Data.CommandType.StoredProcedure, transaction: _transaction);
        }

        public int GetId(string username)
        {
            DynamicParameters parameters = new();
            parameters.Add("UserName", username, System.Data.DbType.String);
            parameters.Add("ID", dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);

            _connection.Execute("sp_GetUserId", parameters, commandType: System.Data.CommandType.StoredProcedure);

            return parameters.Get<int>("ID");
        }

        public void LockUser(string username)
        {
            DynamicParameters parameters = new();
            parameters.Add("UserName", username, System.Data.DbType.String);

            _connection.Execute("sp_LockUser", parameters, commandType: System.Data.CommandType.StoredProcedure);
        }

        public void UnlockUser(string username)
        {
            DynamicParameters parameters = new();
            parameters.Add("UserName", username, System.Data.DbType.String);

            _connection.Execute("sp_UnlockUser", parameters, commandType: System.Data.CommandType.StoredProcedure);
        }

        protected override IEnumerable<string> IgnoredPropertiesForInsert
        {
            get
            {
                List<string> ignoredParameters = base.IgnoredPropertiesForInsert.ToList();
                ignoredParameters.Add("IsActive");
                return ignoredParameters;
            }
        }

        protected override IEnumerable<string> IgnoredPropertiesForUpdate
        {
            get
            {
                List<string> ignoredParameters = base.IgnoredPropertiesForInsert.ToList();
                ignoredParameters.Add("Password");
                return ignoredParameters;
            }
        }
    }
}

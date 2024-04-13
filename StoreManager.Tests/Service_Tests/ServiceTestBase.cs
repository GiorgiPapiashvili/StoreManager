using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Tests.Service_Tests
{
    public class ServiceTestBase : IDisposable
    {
        protected const string ConnectionString = "Server = .; Database = StoreManager.Database; Integrated Security = SSPI; TrustServerCertificate = true;";
        protected SqlConnection connection;

        public ServiceTestBase()
        {
            connection = new(ConnectionString);
        }

        public virtual void Dispose()
        {
            connection.Dispose();
        }
    }
}

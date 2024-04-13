using Dapper;
using Microsoft.Data.SqlClient;
using StoreManager.DTO;
using StoreManager.Service.Interfaces.Repositories;
using System.Data;

namespace StoreManager.Repository
{
    internal sealed class SaleDetailRepository : RepositoryBase<SaleDetail>, ISaleDetailRepository
    {
        public SaleDetailRepository(string connectionString) : base(connectionString)
        {

        }
        public override int Insert(SaleDetail item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("SaleId", item.SaleId, DbType.Int32);
            parameters.Add("ProductId", item.ProductId, DbType.Int32);
            parameters.Add("UnitPrice", item.UnitPrice, DbType.Decimal);
            parameters.Add("Quantity", item.Quantity, DbType.Int32);

            _connection.Execute("sp_InsertPurchaseDetail", parameters, commandType: CommandType.StoredProcedure);
            return 0;
        }
    }
}

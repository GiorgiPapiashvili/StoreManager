using StoreManager.DTO;
using StoreManager.Service.Interfaces.Repositories;
using System.Data;

namespace StoreManager.Repository
{
    internal sealed class PurchaseRepository : RepositoryBase<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(string connectionString) : base(connectionString)
        {

        }
        protected override IEnumerable<string> IgnoredPropertiesForInsert
        {
            get
            {
                List<string> purchaseIgnoredProperty = base.IgnoredPropertiesForInsert.ToList();

                purchaseIgnoredProperty.Add("PurchaseDate");

                return purchaseIgnoredProperty;
            }
        }
        protected override IEnumerable<string> IgnoredPropertiesForUpdate
        {
            get
            {
                List<string> purchaseIgnoredProperty = base.IgnoredPropertiesForUpdate.ToList();

                purchaseIgnoredProperty.AddRange(new List<string>() { "PurchaseDate", "SupplierId", "EmployeeId" });

                return purchaseIgnoredProperty;
            }
        }
    }
}

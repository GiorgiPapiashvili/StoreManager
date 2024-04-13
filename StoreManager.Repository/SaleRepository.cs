using StoreManager.DTO;
using StoreManager.Service.Interfaces.Repositories;

namespace StoreManager.Repository
{
    internal sealed class SaleRepository : RepositoryBase<Sale>, ISaleRepository
    {
        public SaleRepository(string connectionString) : base(connectionString)
        {

        }
        protected override IEnumerable<string> IgnoredPropertiesForInsert
        {
            get
            {
                List<string> salesIgnoredProperties = base.IgnoredPropertiesForInsert.ToList();

                salesIgnoredProperties.Add("SaleDate");

                return salesIgnoredProperties;
            }
        }

        protected override IEnumerable<string> IgnoredPropertiesForUpdate
        {
            get
            {
                List<string> salesIgnoredProperties = base.IgnoredPropertiesForUpdate.ToList();
                salesIgnoredProperties.AddRange(new List<string>() { "SaleDate", "CustomerId", "EmployeeId" });

                return salesIgnoredProperties;
            }
        }
    }
}

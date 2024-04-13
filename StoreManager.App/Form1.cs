using StoreManager.DTO;
using StoreManager.Service.Interfaces.Repositories;
using StoreManager.Repository;
using StoreManager.Service;

namespace StoreManager.App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IUnitOfWork unitOfWork = new UnitOfWork("Server = .; Database = StoreManager.Database; Integrated Security = SSPI; TrustServerCertificate = true");
            unitOfWork.GetConnection();
            unitOfWork.BeginTransaction();
            //unitOfWork.Dispose();



            //try
            //{
            //    //unitOfWork.BeginTransaction();

               
                
            //    //service.Login("Giorgi", "Giorgi");
            //    //unitOfWork.CommitTransaction();
            //}
            //catch (Exception ex)
            //{
            //    //unitOfWork.RollBackTransaction();
            //    throw;
            //}

            
            //IUserRepository user = new UserRepository("Data Source=.; database=TestDatabase; Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Connect Timeout=60;Encrypt=False;Trust Server Certificate=False;Command Timeout=0");
            //User user1 = new() { UserName = "Infernal12", IsActive = true, EmployeeId = 1 };
            //user.Register(12,"Mathilda Gvaliani","MidiMovdivar");

            //int id = user.GetId("Giushki");

            //Console.ReadLine();

            //CountryRepository countryRepository = new("Data Source=.; database=store; Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Connect Timeout=60;Encrypt=False;Trust Server Certificate=False;Command Timeout=0");
            //Country country = new() { Name = "Georgia" };
            //countryRepository.Insert(country);

            //CityRepository cityRepository = new("Data Source=.; database=store; Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Connect Timeout=60;Encrypt=False;Trust Server Certificate=False;Command Timeout=0");
            //City city = new() { CountryId = 1, Name = "Tbilisi" };
            //cityRepository.Insert(city);

            //categoryRepository categoryRepository = new("Data Source=.; database=store; Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Connect Timeout=60;Encrypt=False;Trust Server Certificate=False;Command Timeout=0");
            //Category category = new() { Name = "Category 1" };
            //categoryRepository.Insert(category);

            //CustomerRepository customerRepository = new("Data Source=.; database=store; Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Connect Timeout=60;Encrypt=False;Trust Server Certificate=False;Command Timeout=0");
            //Customer customer = new() { CityId = 1, FirstName = "Customer1", LastName = "Surname" };
            //customerRepository.Insert(customer);

            //EmployeeTypeRepository employeeTypeRepository = new("Data Source=.; database=store; Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Connect Timeout=60;Encrypt=False;Trust Server Certificate=False;Command Timeout=0");
            //EmployeeType empType = new() { Name = "Type1", Description = null };
            //employeeTypeRepository.Insert(empType);


            //EmployeeRepository employeeRepository = new("Data Source=.; database=store; Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Connect Timeout=60;Encrypt=False;Trust Server Certificate=False;Command Timeout=0");
            //Employee employee = new() { EmployeeTypeId = 1, CityId = 1, FirstName = "Employee1", LastName = "LastName", Email = "Gmail", Phone = "1233", IdentityNumber = "12323" };
            //employeeRepository.Insert(employee);

            //ProductRepository productRepository = new("Data Source=.; database=store; Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Connect Timeout=60;Encrypt=False;Trust Server Certificate=False;Command Timeout=0");
            //Product product = new() { CategoryId = 1, Name = " Product1", ProductCode = "1212", UnitPrice = 13.22m, };
            //productRepository.Insert(product);

            //SupplierRepository supplierRepository = new("Data Source=.; database=store; Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Connect Timeout=60;Encrypt=False;Trust Server Certificate=False;Command Timeout=0");
            //Supplier supplier = new() { CityId = 1, Name = "Supplier1", Email = "Gmail", Phone = "-", TaxCode = "1211" };
            //supplierRepository.Insert(supplier);

            //PurchaseRepository purchaseRepository = new("Data Source=.; database=store; Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Connect Timeout=60;Encrypt=False;Trust Server Certificate=False;Command Timeout=0");
            //Purchase purchase = new() { EmployeeId = 1, SupplierId = 1, Status = SignStatus.InProgress };
            //purchaseRepository.Insert(purchase);

            //PurchaseDetailsRepository purchaseDetailsRepository = new("Data Source=.; database=store; Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Connect Timeout=60;Encrypt=False;Trust Server Certificate=False;Command Timeout=0");
            //PurchaseDetail purchaseDetail = new() { ProductId = 1, PurchaseId = 3, Quantity = 2, UnitPrice = 22m };
            //purchaseDetailsRepository.Insert(purchaseDetail);

            //SaleRepository saleRepository = new("Data Source=.; database=store; Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Connect Timeout=60;Encrypt=False;Trust Server Certificate=False;Command Timeout=0");
            //Sale sale = new() { CustomerId = 1, EmployeeId = 1, Status = SignStatus.Completed };
            //saleRepository.Insert(sale);

            //SaleDetailRepository saleDetailRepository = new("Data Source=.; database=store; Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Connect Timeout=60;Encrypt=False;Trust Server Certificate=False;Command Timeout=0");
            //SaleDetail saleDetail = new() { SaleId = 2, ProductId = 1, Quantity = 1, UnitPrice = 12.11m };
            //saleDetailRepository.Insert(saleDetail);
        }

    }
}
using Microsoft.Data.SqlClient;
using StoreManager.Repository;
using StoreManager.Service;
using StoreManager.Service.Interfaces.Repositories;

namespace StoreManager.Tests.Service_Tests;

public class UserServiceTest : ServiceTestBase
{
    public UserServiceTest()
    {
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "insert into EmployeeTypes(Name) values('Type1') " +
                              "insert into Countries(Name) values('Country1') " +
                              "insert into Cities(CountryId, Name) values(1,'City1') " +
                              "Insert Into Employees(EmployeeTypeId, FirstName, LastName, IdentityNumber, Email, Phone, CityId) values(1, 'Name', 'LastName','-','Mail','-',1)";
        connection.Open();
        command.ExecuteNonQuery();
    }

    [Fact]
    public void RegisterUser()
    {
        IUnitOfWork unitOfWork = new UnitOfWork(ConnectionString);
        UserService userService = new UserService(unitOfWork);

        string userName = "UserName";
        string password = "Password";
        userService.Register(1, userName, "Password");

        /// Password not match
        Assert.Throws<SqlException>(() => userService.Login(userName, userName));

        ///Username not match       
        Assert.Throws<SqlException>(() => userService.Login("Name", password));

        bool succesfullLogin = userService.Login(userName, password);
        Assert.True(succesfullLogin);
    }

    [Fact]
    public void LoginUser()
    {
        IUnitOfWork unitOfWork = new UnitOfWork(ConnectionString);
        UserService userService = new UserService(unitOfWork);

        string userName = "Name";
        string userPassword = "Password";

        userService.Register(1, userName, userPassword);

        var successfullLogin = userService.Login(userName, userPassword);

        Assert.True(successfullLogin);
    }

    [Fact]
    public void ChangePasswordUser()
    {
        IUnitOfWork unitOfWork = new UnitOfWork(ConnectionString);
        UserService userService = new UserService(unitOfWork);

        string userName = "UserName";
        string password = "Password";
      
        userService.Register(1, userName, password);
        Assert.True(userService.Login(userName, password));

        string newPassword = "NewPassword";
        userService.ResetPassword(userName, password, newPassword);

        //Login Attempt with old password
        Assert.Throws<SqlException>(() => userService.Login(userName, password));

        //Login Attempt with new password
        Assert.True(userService.Login(userName, newPassword));
    }

    [Fact]
    public void LockUser()
    {
        IUnitOfWork unitOfWork = new UnitOfWork(ConnectionString);
        UserService userService = new UserService(unitOfWork);

        string userName = "Name";
        string password = "Password";

        userService.Register(1, userName, password);

        Assert.True(userService.Login(userName, password));

        userService.LockUser(userName);
        Assert.Throws<SqlException>(() => userService.Login(userName, password));
    }

    [Fact]
    public void UnlockLockUser()
    {
        IUnitOfWork unitOfWork = new UnitOfWork(ConnectionString);
        UserService userService = new UserService(unitOfWork);

        string userName = "Name";
        string password = "Password";

        userService.Register(1, userName, password);
        userService.LockUser(userName);
        Assert.Throws<SqlException>(() => userService.Login(userName, password));

        userService.UnlockUser(userName);
        Assert.True(userService.Login(userName, password));
    }

    public override void Dispose()
    {
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "Delete Users " +
                              "Delete Employees; DBCC CHECKIDENT('Employees', RESEED, 0) " +
                              "Delete Cities; DBCC CHECKIDENT('Cities', RESEED, 0) " +
                              "Delete Countries; DBCC CHECKIDENT('Countries', RESEED, 0) " +
                              "Delete EmployeeTypes; DBCC CHECKIDENT('EmployeeTypes', RESEED, 0)";
        command.ExecuteNonQuery();
        base.Dispose();
    }
}

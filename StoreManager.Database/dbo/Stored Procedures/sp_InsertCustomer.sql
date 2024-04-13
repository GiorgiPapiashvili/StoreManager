create procedure sp_InsertCustomer
@FirstName nvarchar(50),
@LastName nvarchar(50),
@Email nvarchar(100),
@Phone varchar(20),
@AddressLine1 nvarchar(100),
@AddressLine2 nvarchar(100),
@ZipCode nvarchar(50),
@CityID nvarchar(50),
@ID int out
as
begin
	set nocount on;
 
	insert into Customers(FirstName, LastName, Email, Phone, AddressLine1, Addressline2, ZipCode, CityID)
	values (@FirstName, @LastName, @Email, @Phone, @AddressLine1, @AddressLine2, @ZipCode, @CityID)

	set @ID = @@IDENTITY;

	return 0;
end

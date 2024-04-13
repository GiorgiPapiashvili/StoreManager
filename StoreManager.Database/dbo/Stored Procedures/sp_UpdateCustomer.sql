create procedure sp_UpdateCustomer
@CustomerId int,
@FirstName nvarchar(50),
@LastName nvarchar(50),
@Email nvarchar(100),
@Phone varchar(20),
@AddressLine1 nvarchar(100),
@AddressLine2 nvarchar(100),
@ZipCode nvarchar(50),
@CityID int
as
begin
	set nocount on;

	update Customers
	set FirstName = @FirstName,
		LastName = @LastName,
		Email = @Email,
		Phone = @Phone,
		AddressLine1 = @AddressLine1,
		Addressline2 = @AddressLine2,
		ZipCode = @ZipCode,
		CityID = @CityID,
		UpdateDate = GetDate()
	where CustomerID = @CustomerId and IsDeleted = 0;

	return 0;
end

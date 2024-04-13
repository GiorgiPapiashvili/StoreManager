create procedure sp_UpdateSupplier
@SupplierId int,
@Name nvarchar(100),
@TaxCode varchar(11),
@Email nvarchar(100),
@Phone varchar(20),
@AddressLine1 nvarchar(100),
@AddressLine2 nvarchar(100),
@ZipCode nvarchar(50),
@CityID int
as
begin	
	set nocount on;

		update Suppliers
		set Name = @Name,
			TaxCode = @TaxCode,
			Email = @Email,
			Phone = @Phone,
			AddressLine1 = @AddressLine1,
			Addressline2 = @AddressLine2,
			ZipCode = @ZipCode,
			CityID = @CityID,
			UpdateDate = GetDate()
		where SupplierID = @SupplierId and IsDeleted = 0;

	return 0;
end
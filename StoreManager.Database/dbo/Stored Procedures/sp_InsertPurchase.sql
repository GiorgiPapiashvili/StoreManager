create procedure sp_InsertPurchase
@SupplierID int,
@EmployeeID int,
@Status tinyint,
@ID int out
as
begin
	set nocount on;

		insert into Purchases(SupplierID, EmployeeID, Status) values (@SupplierID, @EmployeeID, @Status);

		set @ID = @@IDENTITY;
		
	return 0;
end
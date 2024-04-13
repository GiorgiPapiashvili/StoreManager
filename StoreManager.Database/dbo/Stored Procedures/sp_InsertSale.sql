create procedure sp_InsertSale
@EmployeeID int,
@CustomerID int,
@Status tinyint,
@ID int out
as
begin
	set nocount on;

		insert into Sales(EmployeeID, CustomerID, Status) 
		values (@EmployeeID, @CustomerID, @Status);

		set @ID = @@IDENTITY;
		
	return 0;
end
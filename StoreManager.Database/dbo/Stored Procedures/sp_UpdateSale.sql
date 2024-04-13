create procedure sp_UpdateSale
@SaleID int,
@Status tinyint
as 
begin
	set nocount on;

	update Sales
	set Status = @Status
	where SaleID = @SaleID;

	return 0;
end

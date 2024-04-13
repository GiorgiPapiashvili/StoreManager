create procedure sp_InsertSaleDetail
@SaleID int,
@ProductID int,
@UnitPrice money,
@Quantity int
as
begin
	set nocount on;

		insert into SaleDetails(SaleID, ProductID, UnitPrice, Quantity) 
		values (@SaleID, @ProductID, @UnitPrice, @Quantity)
		
	return 0;
end
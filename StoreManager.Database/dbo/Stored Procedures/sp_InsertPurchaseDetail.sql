create procedure sp_InsertPurchaseDetail
@PurchaseID int,
@ProductID int,
@UnitPrice money,
@Quantity int
as
begin
	set nocount on;

		insert into PurchaseDetails(PurchaseID, ProductID, UnitPrice, Quantity)
		values (@PurchaseID, @ProductID, @UnitPrice, @Quantity)
		
	return 0;
end
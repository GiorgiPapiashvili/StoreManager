create procedure sp_UpdatePurchase
@PurchaseId int,
@Status tinyint
as
begin
	set nocount on;

	update Purchases
	set Status = @Status
	where PurchaseID = @PurchaseId;

	return 0;
end

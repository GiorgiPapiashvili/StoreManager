create procedure sp_UpdateProduct
@ProductId int,
@CategoryID int,
@ProductCode varchar(10),
@Description nvarchar(1000),
@Name nvarchar(50),
@UnitPrice money
as
begin
	set nocount on;

		Update Products
		set CategoryID = @CategoryID,
			ProductCode = @ProductCode,
			Name = @Name,
			Description = @Description,
			UnitPrice = @UnitPrice,
			UpdateDate = GetDate()
		where ProductID = @ProductId and IsDeleted = 0;
		
	return 0;
end
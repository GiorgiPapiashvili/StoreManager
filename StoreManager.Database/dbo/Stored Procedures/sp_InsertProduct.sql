create procedure sp_InsertProduct
@CategoryID int,
@ProductCode varchar(10),
@Name nvarchar(50),
@Description nvarchar(1000),
@UnitPrice money,
@ID int out
as
begin
	set nocount on;

		insert into Products(CategoryID, ProductCode, Name, Description, UnitPrice) values (@CategoryID, @ProductCode, @Name, @Description, @UnitPrice)

		set @ID = @@IDENTITY
		
	return 0;
end
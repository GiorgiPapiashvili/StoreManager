create procedure sp_InsertCategory
@Name nvarchar(50),
@Description nvarchar(1000),
@ID int out
as
begin
	set nocount on;

	insert into Categories(Name, Description)
	values(@Name, @Description);

	set @ID = @@IDENTITY;
	
	return 0;
end

create procedure sp_UpdateCategory
@CategoryId int,
@Name nvarchar(50),
@Description nvarchar(1000)
as
begin
	set nocount on;

	update Categories
	set Name = @Name, 
		Description = @Description,
		UpdateDate = GetDate()
	where CategoryID = @CategoryId and IsDeleted = 0;
	
	return 0;
end
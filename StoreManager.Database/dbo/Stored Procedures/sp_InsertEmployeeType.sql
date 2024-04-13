create procedure sp_InsertEmployeeType
@Name nvarchar(50),
@Description nvarchar(1000),
@ID int out
as
begin
	set nocount on;

	insert into EmployeeTypes(Name, Description)
	values(@Name, @Description)

	set @ID = @@IDENTITY;

	return 0;
end

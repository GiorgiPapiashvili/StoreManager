create procedure sp_UpdateEmployeeType
@EmployeeTypeId int,
@Name nvarchar(50),
@Description nvarchar(1000)
as
begin 
	set nocount on;

	update EmployeeTypes
	set Name = @Name,
		Description = @Description,
		UpdateDate = GetDate()
	where EmployeeTypeID = @EmployeeTypeId and IsDeleted = 0;

	return 0;
end

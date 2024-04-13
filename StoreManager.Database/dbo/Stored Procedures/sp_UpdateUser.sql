create procedure sp_UpdateUser
@EmployeeID int,
@UserName nvarchar(50),
@IsActive bit
as 
begin
	set nocount on;

	update Users
	set IsActive = @IsActive,
		UserName = @UserName
	where EmployeeId = @EmployeeID;

	return 0;
end
create procedure sp_LockUser
@UserName nvarchar(50)
as
begin
	set nocount on;	

	update Users set IsActive = 0
	where @UserName = UserName and IsActive = 1;
	
	return 0;
end
create procedure sp_UnlockUser
@UserName nvarchar(50)
as
begin
	set nocount on;
	
	update Users set IsActive = 1
	where @UserName = UserName and IsActive = 0;

	return 0;
end
create procedure sp_InsertUser
@EmployeeID int,
@UserName nvarchar(50),
@Password nvarchar(50)
as
begin
	set nocount on;

		insert into Users(EmployeeId, UserName, Password) 
		values (@EmployeeID, @UserName, HASHBYTES ('SHA2_256', @Password));
	
	return 0;
end
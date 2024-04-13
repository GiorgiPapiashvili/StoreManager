create procedure sp_InsertCity
@CountryID int,
@Name nvarchar(100),
@ID int out
as
begin
	set nocount on;

	insert into Cities(CountryID, Name)
	values(@CountryID, @Name);

	set @ID = @@IDENTITY;
	
	return 0;
end


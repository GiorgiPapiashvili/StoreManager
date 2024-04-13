create procedure sp_UpdateCountry
@CountryId int,
@Name nvarchar(100)
as
begin	
	set nocount on;

		update Countries
		set Name = @Name,
			UpdateDate = GetDate()
		where CountryID = @CountryId and IsDeleted = 0;

	return 0;
end
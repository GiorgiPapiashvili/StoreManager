create procedure sp_UpdateCity
@CityId int,
@CountryID int,
@Name nvarchar(100)
as
begin
	set nocount on;

	update Cities
	set CountryID = @CountryID,
		Name = @Name,
		UpdateDate = GetDate()
	where CityID = @CityId and IsDeleted = 0;
	
	return 0;
end
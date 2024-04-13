
--Insert
alter Procedure sp_InsertAddress
@CityID int
as
begin
	set nocount on;

		insert into Addresses(AddressID) values(@CityID)

	return 0;
end

---Update
GO

alter Procedure sp_UpdateAddress
@OldCityID int,
@NewCityID int
as
begin
	
	set nocount on;

		update Addresses
		set AddressID = @NewCityID, 
			UpdateDate = GetDate()
		where AddressID = @OldCityID;

	return 0
end

---Delete
GO

alter procedure sp_DeleteAddress
@CityID int
as
begin
	
	set nocount on;

		update Addresses
		set IsDeleted = 1 where AddressID = @CityID and IsDeleted = 0;

	return 0
end
GO
